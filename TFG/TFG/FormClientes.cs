﻿using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG
{
    public partial class FormClientes : Form
    {

        MySqlDataAdapter adapterAll;
        public DataSet ds = new DataSet();
        MySqlConnection c;
        public static string defaultQuery = "SELECT cliente.id, cliente.nombre, cliente.dni, cliente.direccion, MUNICIPIOS.Municipio AS municipio, PROVINCIAS.Provincia AS provincia, cliente.codigo_postal, cliente.telefono1, cliente.telefono2, cliente.email " +
            " FROM cliente JOIN MUNICIPIOS ON cliente.municipio = MUNICIPIOS.idMunicipio JOIN PROVINCIAS ON cliente.provincia = PROVINCIAS.idProvincia" +
            " order by cliente.nombre";
        public string actualQuery = defaultQuery;

        static Dictionary<string, int> splitterSize = new Dictionary<string, int>()
{
    {"cerrado", 38},
    {"filtro", 83},
    {"admod", 100}
};

        bool unsavedChanges = false;
        public FormClientes()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            //this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width-(Screen.PrimaryScreen.WorkingArea.Width/2), 0);
            //abro conexión y la cierro cuando se cierre la aplicación
            //c = new MySqlConnection("server=127.0.0.1;uid=root;pwd=root;database=gestiona");
            c = Program.conn;
            //c = new MySqlConnection("server=sql7.freemysqlhosting.net;uid=sql7606247;pwd=dduU845xle;database=sql7606247");
            //c = new MySqlConnection("server=www.ieslamarisma.net;uid=marcosalfonso;pwd=2pTb92m@;database=marcosalfonso");
            //c.Open();
            //this.Closed += (s, args) => c.Close();

            initConfig();
            iniciaDTG();

            iniciaTablaFiltro();
            //iniciaAdmod();



            //cambioResize(null, null);
            //splitContainer1.Panel2.Padding = new Padding(0, menuStrip1.Height, 0, 0);

        }

        public void iniciaDTG()
        {
            //String query = "SELECT * FROM cliente order by nombre";
            String query = actualQuery;
            adapterAll = new MySqlDataAdapter(query, c);
            //MySqlCommandBuilder cb = new MySqlCommandBuilder(adapterAll);

            adapterAll.UpdateCommand = generaUpdateCommand();
            adapterAll.DeleteCommand = generaDeleteCommand();
            adapterAll.Fill(ds, "cliente");

            dtClientes.DataSource = ds;
            dtClientes.DataMember = "cliente";

            dtClientes.Columns["nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtClientes.Columns["dni"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtClientes.Columns["dni"].ReadOnly = true;
            dtClientes.Columns["id"].Visible = false;
            dtClientes.Columns["provincia"].ReadOnly = true;
            dtClientes.Columns["municipio"].ReadOnly = true;

            toolStripButtonUndo.Enabled = false;
        }

        private MySqlCommand generaDeleteCommand()
        {
            string deleteQuery = "DELETE FROM cliente where id = @id";

            MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, Program.conn);
            deleteCommand.Parameters.Add("@id", MySqlDbType.VarChar, 255, "id");
            return deleteCommand;
        }

        private static MySqlCommand generaUpdateCommand()
        {
            string updateQuery = "UPDATE cliente SET nombre = @nombre, direccion = @direccion, codigo_postal = @codigo_postal, telefono1 = @telefono1, telefono2 = @telefono2, email = @email where dni = @dni";

            MySqlCommand updateCommand = new MySqlCommand(updateQuery, Program.conn);
            updateCommand.Parameters.Add("@nombre", MySqlDbType.VarChar, 255, "nombre");

            updateCommand.Parameters.Add("@direccion", MySqlDbType.VarChar, 255, "direccion");
            updateCommand.Parameters.Add("@codigo_postal", MySqlDbType.VarChar, 255, "codigo_postal");
            updateCommand.Parameters.Add("@telefono1", MySqlDbType.VarChar, 255, "telefono1");
            updateCommand.Parameters.Add("@telefono2", MySqlDbType.VarChar, 255, "telefono2");
            updateCommand.Parameters.Add("@email", MySqlDbType.VarChar, 255, "email");
            updateCommand.Parameters.Add("@dni", MySqlDbType.VarChar, 255, "dni");
            return updateCommand;
        }

        private void initConfig()
        {
            dtClientes.DefaultCellStyle.Font = Settings1.Default.gridFont;
        }

        private void iniciaAdmod()
        {

            // Define el ancho y la altura de los controles
            int anchoLabel = 100;
            int anchoTextBox = 250;
            int alturaControl = 25;

            Panel panel = new Panel();

            agregaTitulosFlow();
            // Agrega los controles al FlowLayoutPanel
            foreach (DataGridViewColumn columna in dtClientes.Columns)
            {
                Label label = new Label();
                //El nombre de la columna no debe mostrar los carácteres "_"
                string nombreColumna = columna.HeaderText.Replace("_", " ");

                label.Text = nombreColumna + ":";

                label.Width = anchoLabel;
                label.Height = alturaControl;
                label.TextAlign = ContentAlignment.MiddleCenter;
                TextBox textBox = new TextBox();
                textBox.Width = anchoTextBox;
                textBox.Height = alturaControl;

                // Crea un Panel para contener el par de controles
                panel = new Panel();
                panel.Width = anchoLabel + anchoTextBox + 10;
                //panel.BackColor = Color.White;
                panel.Height = alturaControl;
                panel.Controls.Add(label);
                panel.Controls.Add(textBox);

                // Agrega el panel al FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(panel);
                panel.AutoSize = true;

            }
            flowLayoutPanel1.SetFlowBreak(panel, true);

            Button btnAceptar = new Button();
            btnAceptar.Text = "Aceptar";
            flowLayoutPanel1.Controls.Add(btnAceptar);
        }
        Panel panelAlta = new Panel();
        Panel panelMod = new Panel();
        private void agregaTitulosFlow()
        {
            panelAlta = new Panel();
            panelAlta.BackColor = ColorTranslator.FromHtml("#94d82d");
            panelAlta.Size = new Size(100, 50);
            flowLayoutPanel1.Controls.Add(panelAlta);

            Label labelAlta = new Label();
            labelAlta.Text = "ALTA";
            labelAlta.Font = new Font("Arial", 18, FontStyle.Bold);
            labelAlta.ForeColor = Color.White;
            labelAlta.Dock = DockStyle.Fill;
            labelAlta.TextAlign = ContentAlignment.MiddleCenter;
            panelAlta.Controls.Add(labelAlta);

            // Añadir el Panel al FlowLayoutPanel
            flowLayoutPanel1.Controls.Add(panelAlta);
            flowLayoutPanel1.SetFlowBreak(panelAlta, true);

            panelMod = new Panel();
            panelMod.BackColor = ColorTranslator.FromHtml("#fcc419");
            panelMod.Size = new Size(180, 50);

            flowLayoutPanel1.Controls.Add(panelMod);

            Label labelMod = new Label();
            labelMod.Text = "Modificación";
            labelMod.Font = new Font("Arial", 18, FontStyle.Bold);
            labelMod.ForeColor = Color.White;
            labelMod.Dock = DockStyle.Fill;
            labelMod.TextAlign = ContentAlignment.MiddleCenter;
            panelMod.Controls.Add(labelMod);

            // Añadir el Panel al FlowLayoutPanel
            flowLayoutPanel1.Controls.Add(panelMod);
            flowLayoutPanel1.SetFlowBreak(panelMod, true);


            panelAlta.Visible = false;
            panelMod.Visible = false;
        }

        private void iniciaTablaFiltro()
        {

            foreach (DataGridViewColumn col in dtClientes.Columns)
            {
                if (string.Equals(col.Name, "id", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                int index = dtFiltro.Columns.Add(col.Name, col.HeaderText);
                // dtFiltro.Columns[index].FillWeight = col.FillWeight;
            }
            dtFiltro.Rows.Add();

        }

        private void cambioResize(object sender, EventArgs e)
        {
            try
            {


                if (this.WindowState == FormWindowState.Maximized)
                {
                    dtClientes.Columns["direccion"].Visible = true;
                    dtClientes.Columns["municipio"].Visible = true;
                    dtClientes.Columns["provincia"].Visible = true;
                    dtClientes.Columns["codigo_postal"].Visible = true;
                    splitContainer1.SplitterDistance = splitterSize["cerrado"];
                }
                else if (Settings1.Default.hideColumns)
                {

                    dtClientes.Columns["direccion"].Visible = false;
                    dtClientes.Columns["municipio"].Visible = false;
                    dtClientes.Columns["provincia"].Visible = false;
                    dtClientes.Columns["codigo_postal"].Visible = false;

                }

            }
            catch (Exception notFound)
            {


            }
            //compruebo como estaba el filtro, añadir/modificar porque se mueve al cambiar el tamaño
            if (splitContainer2.Panel2Collapsed)
            {
                splitContainer1.SplitterDistance = splitterSize["filtro"];

            }
            else if (splitContainer2.Panel1Collapsed)
            {
                splitContainer1.SplitterDistance = 38;
                while (flowLayoutPanel1.VerticalScroll.Visible)
                {
                    splitContainer1.SplitterDistance += 10;
                }
                splitContainer1.SplitterDistance += 15;
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

            toolStripButtonSave.Enabled = false;
            unsavedChanges = false;
            toolStripButtonUndo.Enabled = false;
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
        private void darAlta(object sender, EventArgs e)
        {

        }
        private void cambioGrid(object sender, DataGridViewCellEventArgs e)
        {
            unsavedChanges = true;
            toolStripButtonUndo.Enabled = true;
            toolStripButtonSave.Enabled = true;
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
                        toolStripButtonSave.Enabled = true;
                        toolStripButtonUndo.Enabled = true;
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

                splitContainer1.Panel1Collapsed = true;

                dtClientes.DataSource = ds;
                return;
            }

            splitContainer1.SplitterDistance = splitterSize["filtro"];
            splitContainer2.Panel2Collapsed = true;
            splitContainer2.Panel1Collapsed = false;
            splitContainer1.Panel1Collapsed = false;
            cambioFiltro(null, null);
        }

        private void abreVentanaFiltro(object sender, EventArgs e)
        {
            // Verificar si el formulario ya está abierto
            if (Application.OpenForms.OfType<FormFiltro>().Any())
            {
                // Obtener la instancia del formulario existente
                FormFiltro formFiltro = Application.OpenForms.OfType<FormFiltro>().First();

                // Mostrar el formulario en primer plano
                formFiltro.BringToFront();
            }
            else
            {
                // Si el formulario no está abierto, crear una nueva instancia y mostrarlo
                FormFiltro formFiltro = new FormFiltro();
                formFiltro.formClientes = this;
                formFiltro.Show();
                formFiltro.BringToFront();
            }
        }
        private void abreAdmod(object sender, EventArgs e)
        {

            if (splitContainer2.Panel1Collapsed)
            {
                splitContainer1.SplitterDistance = splitterSize["cerrado"];
                splitContainer2.Panel1Collapsed = false;
                splitContainer1.Panel1Collapsed = true;
                splitContainer1.Panel2.Padding = new Padding(0, menuStrip1.Height, 0, 0);

                panelMod.Visible = false;
                panelAlta.Visible = false;
                return;
            }

            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem != null && menuItem.Name == "altaToolStripMenuItem")
            {
                panelMod.Visible = false;
                panelAlta.Visible = true;

            }
            else if (menuItem != null && menuItem.Name == "modToolStripMenuItem")
            {
                panelAlta.Visible = false;
                panelMod.Visible = true;
            }

            splitContainer2.Panel1Collapsed = true;
            splitContainer2.Panel2Collapsed = false;
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel2.Padding = new Padding(0, 0, 0, 0);
            while (flowLayoutPanel1.VerticalScroll.Visible)
            {
                splitContainer1.SplitterDistance += 5;
            }
            splitContainer1.SplitterDistance += 15;

        }

        private void cambioFiltro(object sender, DataGridViewCellEventArgs e)
        {
            string query = "SELECT * FROM cliente WHERE ";

            foreach (DataGridViewColumn col in dtFiltro.Columns)
            {
                query += $"{col.HeaderText} LIKE '%{dtFiltro.Rows[0].Cells[col.Name].Value}%' ";

                //solo añado and al final si no es la ultima iteracion
                if (!(col == dtFiltro.Columns[dtFiltro.Columns.Count - 1]))
                {
                    query += "AND ";
                }


            }

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, c);
            DataSet dsFiltro = new DataSet();
            adapter.Fill(dsFiltro, "cliente");
            MySqlCommandBuilder cb = new MySqlCommandBuilder(adapter);

            dtClientes.DataSource = dsFiltro;
            dtClientes.DataMember = "cliente";
            dtClientes.Refresh();
        }

        private void verTodasLasCitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCalendario f = new FormCalendario();
            f.ShowDialog();
        }

        private void tsmConfig_Click(object sender, EventArgs e)
        {
            FormConfig f = new FormConfig();
            f.ShowDialog();
            initConfig();
        }

        private void toolClienteLog_Click(object sender, EventArgs e)
        {
            if (dtClientes.SelectedRows.Count == 0)
            {
                return;
            }
            FormClienteLog f = new FormClienteLog(dtClientes.SelectedRows[0].Cells["Dni"].Value.ToString(), dtClientes.SelectedRows[0].Cells["Nombre"].Value.ToString());
            f.ShowDialog();
        }

        private void toolStripMenuItemExportDB_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                // Configurar el diálogo de guardado de archivo
                dialog.Title = "Exportar base de datos";
                dialog.Filter = "Archivos SQL (*.sql)|*.sql";
                dialog.DefaultExt = ".sql";

                // Mostrar el diálogo y obtener el resultado
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string rutaArchivo = dialog.FileName;

                    try
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            using (MySqlBackup mb = new MySqlBackup(cmd))
                            {
                                cmd.Connection = Program.conn;
                                mb.ExportInfo.ExcludeTables = new List<string> { "usuario", "tabla_control", "MUNICIPIOS", "PROVINCIAS", "CCAA" }; ;
                                mb.ExportToFile(rutaArchivo);
                            }
                        }

                        MessageBox.Show("Base de datos exportada exitosamente.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al exportar la base de datos: {ex.Message}");
                    }
                }
            }
        }

        private void toolStripButtonUndo_Click(object sender, EventArgs e)
        {
            if (unsavedChanges == true)
            {

                DialogResult dr = MessageBox.Show("Si recargas se perderán los datos. ¿Desea guardar los cambios antes?", "Alerta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                else if (dr == DialogResult.Yes)
                {
                    guardar(null, null);
                }

            }
            ds.Tables["cliente"].Clear();
            iniciaDTG();
            unsavedChanges = false;
            toolStripButtonSave.Enabled = false;
            toolStripButtonUndo.Enabled = false;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dtClientes.SelectedRows.Count == 0)
            {
                return;
            }

            if (unsavedChanges)
            {
                // Se han realizado cambios no guardados
                DialogResult result = MessageBox.Show("Hay cambios no guardados. ¿Desea guardar los cambios?", "Guardar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    guardar(null, null);
                }
                else
                {
                    return;
                }
            }

            FormVistaCliente f = new FormVistaCliente(Convert.ToInt32(dtClientes.SelectedRows[0].Cells["id"].Value), false);
            f.ShowDialog();

            ds.Tables["cliente"].Clear();
            iniciaDTG();
        }

        private void abreModificar(object sender, EventArgs e)
        {
            if (dtClientes.SelectedRows.Count > 0)
            {
                if (unsavedChanges)
                {
                    // Se han realizado cambios no guardados
                    DialogResult result = MessageBox.Show("Hay cambios no guardados. ¿Desea guardar los cambios?", "Guardar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        guardar(null, null);
                    }
                    else
                    {
                        return;
                    }
                }

                FormVistaCliente f = new FormVistaCliente(Convert.ToInt32(dtClientes.SelectedRows[0].Cells["id"].Value), true);
                f.ShowDialog();

                ds.Tables["cliente"].Clear();
                iniciaDTG();
            }

        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            if (unsavedChanges)
            {
                // Se han realizado cambios no guardados
                DialogResult result = MessageBox.Show("Hay cambios no guardados. ¿Desea guardar los cambios?", "Guardar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    guardar(null, null);
                }
                else
                {
                    return;
                }
            }
            FormVistaCliente f = new FormVistaCliente();
            f.ShowDialog();

            ds.Tables["cliente"].Clear();
            iniciaDTG();
        }

        private void dtClientes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dtClientes.HitTest(e.X, e.Y);
                dtClientes.ClearSelection();

                if (hti.RowIndex ==-1)
                {
                    return;
                }
                dtClientes.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mail.google.com/mail/u/0/?view=cm&fs=1&to=correo@gmail.com");
        }

        private void escribirCorreoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtClientes.SelectedRows.Count == 1)
            {
                try
                {
                    System.Diagnostics.Process.Start($"https://mail.google.com/mail/u/0/?view=cm&fs=1&to={dtClientes.SelectedRows[0].Cells["email"].Value} ");

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al abrir correo: {ex.Message}");
                }
            }
        }

        private void verCorreosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtClientes.SelectedRows.Count == 1)
            {
                try
                {
                    System.Diagnostics.Process.Start($"https://mail.google.com/mail/u/0/#search/{dtClientes.SelectedRows[0].Cells["email"].Value} ");

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al abrir correo: {ex.Message}");
                }
            }
        }
    }
}
