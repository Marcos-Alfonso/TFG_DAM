using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG
{
    public partial class FormDBlogin : Form
    {
        public FormDBlogin()
        {
            InitializeComponent();

            Settings1.Default.Reload();
            tbUser.Text = Settings1.Default.dbUser;
            tbServer.Text = Settings1.Default.dbServer;
            tbPass.Text = Settings1.Default.dbPass;
            tbTabla.Text = Settings1.Default.dbBase;
        }

        private void FormDBlogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiaCampos();
            String query = $"server={tbServer.Text};uid={tbUser.Text};pwd={tbPass.Text};database={tbTabla.Text}";
            //query = "server=www.ieslamarisma.net;uid=marcosalfonso;pwd=2pTb92m@;database=marcosalfonso;";
            this.Cursor = Cursors.WaitCursor;
            try
            {
                Program.conn = new MySqlConnection(query);
                // Program.conn  = new MySqlConnection("server=www.ieslamarisma.net;uid=marcosalfonso;pwd=2pTb92m@;database=marcosalfonso");
                Program.conn.Open();

                bool tablasExistentes = true;

                using (MySqlCommand command = Program.conn.CreateCommand())
                {
                    List<string> tablas = new List<string>
                        {
                            "cliente","usuario","cita",
                            "MUNICIPIOS","PROVINCIAS"
                        };

                    foreach (string s in tablas)
                    {
                        command.CommandText = $"SHOW TABLES LIKE '{s}'";
                        object result = command.ExecuteScalar();
                        tablasExistentes = tablasExistentes & (result != null);
                    }

                }

                if (!tablasExistentes)
                {
                    Program.conn.Close();
                    lbError.Text = "Conexión establecida, pero no se encuentran tablas necesarias.";
                    lbError.Visible = true;
                }

                if (Program.conn.State == ConnectionState.Open)
                {
                    if (cbSave.Checked)
                    {
                        Settings1.Default.dbUser = tbUser.Text;
                        Settings1.Default.dbServer = tbServer.Text;
                        Settings1.Default.dbPass = tbPass.Text;
                        Settings1.Default.dbBase = tbTabla.Text;
                        Settings1.Default.Save();
                    }
                    this.Cursor = Cursors.Default;
                    this.Close();
                }


            }
            catch (MySqlException ex)
            {
                // Capturar el error y mostrar un mensaje adecuado
                //MessageBox.Show($"Error al abrir la conexión, compruebe que las credenciales son correctas.\nError: \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                switch (ex.Number)
                {
                    case 1042:
                        //MessageBox.Show($"No se puede conectar al servidor.\nError completo: \n{ex.Message}\n{query}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lbError.Text = "No se puede conectar al servidor.";
                        tbServer.ForeColor = Color.Red;
                        lbError.Visible = true;
                        break;
                    case 1045:
                        //MessageBox.Show($"Usuario y contraseña inválidos.\nError completo: \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lbError.Text = "Usuario y contraseña inválidos.";
                        tbPass.ForeColor = Color.Red;
                        tbUser.ForeColor = Color.Red;
                        lbError.Visible = true;
                        break;
                    case 1044:
                        lbError.Text = "No tienes permiso para acceder a esta BD.";
                        tbTabla.ForeColor = Color.Red;
                        lbError.Visible = true;
                        break;
                    default:
                        MessageBox.Show($"Error al abrir conexión.\nError completo: \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void limpiaCampos()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.ForeColor = SystemColors.WindowText;
                }
            }
        }
        private void btPass_MouseDown(object sender, MouseEventArgs e)
        {
            tbPass.PasswordChar = '\0';
        }

        private void btPass_MouseUp(object sender, MouseEventArgs e)
        {
            tbPass.PasswordChar = '*';
        }
    }
}



