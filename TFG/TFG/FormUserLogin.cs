using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG
{
    public partial class FormUserLogin : Form
    {
        public FormUserLogin()
        {
            InitializeComponent();
            Settings1.Default.Reload();
            tbUser.Text = Settings1.Default.userName;
            tbPass.Text = Settings1.Default.userPass;
        }

        private void FormUserLogin_Load(object sender, EventArgs e)
        {

        }
        private void btPass_MouseDown(object sender, MouseEventArgs e)
        {
            tbPass.PasswordChar = '\0'; // Mostrar la contraseña como texto normal
        }

        private void btPass_MouseUp(object sender, MouseEventArgs e)
        {
            tbPass.PasswordChar = '*'; // Ocultar la contraseña con asteriscos
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT id FROM usuario WHERE nombre = @usuario AND pass = @pass";
            using (MySqlCommand command = new MySqlCommand(query, Program.conn))
            {
                command.Parameters.AddWithValue("@usuario", tbUser.Text);
                command.Parameters.AddWithValue("@pass", tbPass.Text);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    Program.userId = Convert.ToInt32(result);
                }
            }

            if (Program.userId > 0)
            {
                // El usuario y la contraseña son válidos, se encontró una coincidencia en la tabla.
                if (cbSave.Checked)
                {
                    Settings1.Default.userName = tbUser.Text;
                    Settings1.Default.userPass = tbPass.Text;
                    Settings1.Default.Save();
                }
                this.Close();
            }
            else
            {
                // El usuario y/o la contraseña no son válidos, no se encontró ninguna coincidencia en la tabla
                lbError.Visible = true;
            }
        }
    }
}
