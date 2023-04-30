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

        MySqlDataAdapter adapterAll;
        DataSet ds = new DataSet();
        MySqlConnection c;

        static Dictionary<string, int> splitterSize = new Dictionary<string, int>()
{
    {"cerrado", 38},
    {"filtro", 83},
    {"admod", 100}
};

        bool unsavedChanges = false;
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
            adapterAll = new MySqlDataAdapter(query, c);
            MySqlCommandBuilder cb = new MySqlCommandBuilder(adapterAll);

            adapterAll.Fill(ds, "cliente");

            dtClientes.DataSource = ds;
            dtClientes.DataMember = "cliente";

            dtClientes.Columns["nombre"].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dtClientes.Columns["dni"].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dtClientes.Columns["dni"].ReadOnly = true;



            iniciaTablaFiltro();
            iniciaAdmod();

            dtClientes.ClearSelection();
        }

        private void iniciaAdmod()
        {

            // Define el ancho y la altura de los controles
            int anchoLabel = 100;
            int anchoTextBox = 250;
            int alturaControl = 25;

            // Agrega los controles al FlowLayoutPanel
            foreach (DataGridViewColumn columna in dtClientes.Columns)
            {
                Label label = new Label();
                label.Text = columna.HeaderText;
                label.Width = anchoLabel;
                label.Height = alturaControl;

                TextBox textBox = new TextBox();
                textBox.Width = anchoTextBox;
                textBox.Height = alturaControl;

                // Crea un Panel para contener el par de controles
                Panel panel = new Panel();
                panel.Width = anchoLabel + anchoTextBox + 10;
                panel.BackColor = Color.White;
                panel.Height = alturaControl;
                panel.Controls.Add(label);
                panel.Controls.Add(textBox);

                // Agrega el panel al FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(panel);
                panel.AutoSize = true;

            }


            /*
            // Define el ancho y la altura de los controles
            int anchoLabel = 100;
            int anchoTextBox = 150;
            int alturaControl = 25;

            // Define la posición inicial de los controles
            int x = 10;
            int y = 10;
            int i = 1;

            // Agrega los controles al panel
            foreach (DataGridViewColumn columna in dtClientes.Columns)
            {
                // Crea el Label
                Label label = new Label();
                label.Text = columna.HeaderText;
                label.Width = anchoLabel;
                label.Height = alturaControl;
                if (i%2==0)
                    label.Location = new Point(x+400, y);
                else
                    label.Location = new Point(x, y);
                panelAdmod.Controls.Add(label);

                // Crea el TextBox
                TextBox textBox = new TextBox();
                textBox.Width = anchoTextBox;
                textBox.Height = alturaControl;

                if(i%2 == 0)
                textBox.Location = new Point(x + anchoLabel + 410, y);
                else
                textBox.Location = new Point(x + anchoLabel + 10, y);
                panelAdmod.Controls.Add(textBox);

                if (i % 2 == 0)
                {
                    y += alturaControl + 10;
                }
                
                i ++;
            }
            */
        }

        private void iniciaTablaFiltro()
        {


            foreach (DataGridViewColumn col in dtClientes.Columns)
            {
                int index = dtFiltro.Columns.Add(col.Name, col.HeaderText);
                // dtFiltro.Columns[index].FillWeight = col.FillWeight;
            }
            dtFiltro.Rows.Add();




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
                splitContainer1.SplitterDistance = splitterSize["cerrado"];
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

            //compruebo como estaba el filtro, añadir/modificar porque se mueve al cambiar el tamaño
            if (splitContainer2.Panel2Collapsed)
            {
                splitContainer1.SplitterDistance = splitterSize["filtro"];

            }
            else if (splitContainer2.Panel1Collapsed)
            {
                splitContainer1.SplitterDistance = splitterSize["admod"];
            }

        }


        private void guardar(object sender, EventArgs e)
        {
            dtClientes.Update();

            toolStripStatusLabel1.Visible = false;
            toolStripStatusError.Visible = false;


            //compruebo si no hay datos sin guardar y notifico
            if (!unsavedChanges)
            {
                toolStripStatusError.Text = "No hay datos sin guardar";
                toolStripStatusError.Visible = true;
                return;
            }

            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Visible = true;


            toolStripStatusLabel1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripStatusLabel1.Text = "Guardando datos...";
            toolStripStatusLabel1.Visible = true;

            adapterAll.Update(ds, "cliente");

            toolStripProgressBar1.Value = 100;
            toolStripProgressBar1.Visible = false;

            toolStripStatusLabel1.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            toolStripStatusLabel1.Text = "Datos Guardados!";

            unsavedChanges = false;
        }

        private void closing(object sender, FormClosingEventArgs e)
        {
            //  Defino si cuando cierra se guardan los cambios
            if (unsavedChanges == true)
            {

                DialogResult dr = MessageBox.Show("Hay cambios sin guardar. ¿Desea guardar los cambios?", "Alerta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                else if (dr == DialogResult.Yes)
                {
                    guardar(null, null);
                }
            }

        }
        private void cambioGrid(object sender, DataGridViewCellEventArgs e)
        {
            unsavedChanges = true;
        }

        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //elimina registro seleccionado
            if (dtClientes.SelectedRows.Count > 0)
            {
                String mensaje = "";

                if (dtClientes.SelectedRows.Count == 1)
                {
                    try
                    {
                        mensaje = $"¿Desea eliminar al cliente \"{dtClientes.SelectedRows[0].Cells["nombre"].Value}\" con DNI {dtClientes.SelectedRows[0].Cells["dni"].Value}?";
                    }
                    catch (NullReferenceException nre)
                    {
                        mensaje = $"¿Desea eliminar al cliente seleccionado?";
                    }
                }
                else
                {
                    mensaje = $"¿Desea elminiar a los {dtClientes.SelectedRows.Count} clientes seleccionados?";
                }

                if (MessageBox.Show(mensaje, "Confirmación eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dtClientes.SelectedRows)
                    {
                        dtClientes.Rows.RemoveAt(row.Index);
                        unsavedChanges = true;
                    }
                }
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //control de shortcuts para teclado

            if (e.Control == true && e.KeyCode == Keys.S)
            {
                //guardar
                guardarToolStripMenuItem.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.N)
            {
                //alta
                altaToolStripMenuItem.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.F)
            {
                //filtro
                filtroToolStripMenuItem.PerformClick();
            }
        }

        private void abreFiltro(object sender, EventArgs e)
        {
            //compruebo si ya esta abierto y lo cierro 

            if (splitContainer2.Panel2Collapsed)
            {
                splitContainer1.SplitterDistance = splitterSize["cerrado"];
                splitContainer2.Panel2Collapsed = false;
                return;
            }

            splitContainer1.SplitterDistance = splitterSize["filtro"];
            splitContainer2.Panel2Collapsed = true;
            splitContainer2.Panel1Collapsed = false;
        }

        private void abreAdmod(object sender, EventArgs e)
        {
            /*
            if (splitContainer2.Panel1Collapsed)
            {
                splitContainer1.SplitterDistance = splitterSize["cerrado"];
                splitContainer1.Panel1Collapsed = false;
                return;
            }
            */

            splitContainer1.SplitterDistance = 200;
            splitContainer2.Panel1Collapsed = true;
            splitContainer2.Panel2Collapsed = false;
        }
    }


}
