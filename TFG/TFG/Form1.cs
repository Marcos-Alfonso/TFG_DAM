using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG
{
    public partial class Form1 : Form
    {

        MySqlDataAdapter adapter;
        DataSet ds = new DataSet();
        MySqlConnection c;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            //this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width-(Screen.PrimaryScreen.WorkingArea.Width/2), 0);
            //abro conexión y la cierro cuando se cierre la aplicación
            //c = new MySqlConnection("server=127.0.0.1;uid=root;pwd=root;database=gestiona");
            c = new MySqlConnection("server=sql7.freemysqlhosting.net;uid=sql7606247;pwd=dduU845xle;database=sql7606247");
            c.Open();
            this.Closed += (s, args) => c.Close();

            String query = "SELECT * FROM cliente";
            adapter = new MySqlDataAdapter(query, c);
            MySqlCommandBuilder cb = new MySqlCommandBuilder(adapter);
            adapter.Fill(ds, "cliente");

            dtClientes.DataSource = ds;
            dtClientes.DataMember = "cliente";



            dtClientes.Columns["nombre"].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dtClientes.Columns["dni"].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dtClientes.Columns["dni"].ReadOnly = true;
        }

        private void cambioResize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                /*
                tableLayoutPanel1.RowStyles[0].Height = 10F;
                tableLayoutPanel1.RowStyles[1].Height = 20F;
                tableLayoutPanel1.RowStyles[2].Height = 80F;
                */
                dtClientes.Columns["direccion"].Visible = true;
                dtClientes.Columns["municipio"].Visible = true;
                dtClientes.Columns["provincia"].Visible = true;
                dtClientes.Columns["codigo_postal"].Visible = true;

            }
            else
            {
                dtClientes.Columns["direccion"].Visible = false;
                dtClientes.Columns["municipio"].Visible = false;
                dtClientes.Columns["provincia"].Visible = false;
                dtClientes.Columns["codigo_postal"].Visible = false;
                /*
                tableLayoutPanel1.RowStyles[0].Height = 30F;
                tableLayoutPanel1.RowStyles[1].Height = 20F;
                tableLayoutPanel1.RowStyles[2].Height = 50F;
                */
            }
        }


        private void guardar(object sender, EventArgs e)
        {
            dtClientes.Update();

            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Visible = true;
            toolStripStatusLabel1.Text = "Guardando datos...";
            adapter.Update(ds, "cliente");
            toolStripProgressBar1.Value = 100;
            toolStripProgressBar1.Visible = false;
            toolStripStatusLabel1.Text = "Datos Guardados!";
        }
    }
}
