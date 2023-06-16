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
    public partial class FormFiltro : Form
    {
        public FormClientes formClientes;
        public FormFiltro()
        {
            InitializeComponent();
            cargaProvincia();

        }


        private void cbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMunicipio.Items.Clear();
            var provinciaSeleccionada = (dynamic)cbProvincia.SelectedItem;
            string idProvincia = provinciaSeleccionada.Value;
            string query = "SELECT * FROM MUNICIPIOS where idProvincia = " + idProvincia;

            using (MySqlCommand command = new MySqlCommand(query, Program.conn))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cbMunicipio.Items.Add(new { Value = reader.GetString("idMunicipio"), Text = reader.GetString("Municipio") });
                    }
                }
            }
            cbMunicipio.DisplayMember = "Text";
            if (cbMunicipio.Items.Count > 0)
            {
                cbMunicipio.SelectedIndex = 0;
            }

            foreach (dynamic item in cbMunicipio.Items)
            {
                if (item.Value == "1926")
                {
                    cbMunicipio.SelectedItem = item;
                    break;
                }
            }
        }
        private void tbTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void cargaProvincia()
        {
            string query = "SELECT * FROM PROVINCIAS";

            using (MySqlCommand command = new MySqlCommand(query, Program.conn))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cbProvincia.Items.Add(new { Value = reader.GetString("idProvincia"), Text = reader.GetString("Provincia") });
                    }
                }
            }
            cbProvincia.DisplayMember = "Text";
            foreach (dynamic item in cbProvincia.Items)
            {
                if (item.Value == "21")
                {
                    cbProvincia.SelectedItem = item;
                    break;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cbProvincia.Enabled = !cbProvincia.Enabled;
            lbProvincia.Enabled = !lbProvincia.Enabled;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cbMunicipio.Enabled = !cbMunicipio.Enabled;
            lbMunicipio.Enabled = !lbMunicipio.Enabled;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string query = "SELECT cliente.id, cliente.nombre, cliente.dni, cliente.direccion, MUNICIPIOS.Municipio AS municipio, PROVINCIAS.Provincia AS provincia, cliente.codigo_postal, cliente.telefono1, cliente.telefono2, cliente.email " +
            " FROM cliente JOIN MUNICIPIOS ON cliente.municipio = MUNICIPIOS.idMunicipio JOIN PROVINCIAS ON cliente.provincia = PROVINCIAS.idProvincia ";
            string where = "where ";

            int count = 0;
            foreach (Control control in this.Controls)
            {
                if (control is TextBox tb)
                {
                    if (tb.Text == "")
                    {
                        where += $" ({tb.Name} LIKE '%{tb.Text}%' OR {tb.Name} IS NULL ) ";
                    }
                    else
                    {
                        where += $" ({tb.Name} LIKE '%{tb.Text}%') ";
                    }

                    count++;

                    if (count < this.Controls.OfType<TextBox>().Count())
                    {
                        where += "AND ";
                    }


                }


            }
            if (cbProvincia.Enabled)
            {
                var provinciaSeleccionada = (dynamic)cbProvincia.SelectedItem;
                string idProvincia = provinciaSeleccionada.Value;
                where += " AND cliente.provincia = " + idProvincia;
            }
            if (cbMunicipio.Enabled)
            {
                var municipioSeleccionado = (dynamic)cbMunicipio.SelectedItem;
                string idMunicipio = municipioSeleccionado.Value;
                where += " AND cliente.municipio = " + idMunicipio;
            }

            string textoSeleccionado = "";

            foreach (Control control in groupBox1.Controls)
            {
                if (control is RadioButton rb && rb.Checked)
                {
                    textoSeleccionado = rb.Text;
                    break;
                }
            }
            if (todosVacios() && !cbProvincia.Enabled && !cbMunicipio.Enabled)
            {
                formClientes.actualQuery = query + $" order by {textoSeleccionado};";
            }
            else
            {
                formClientes.actualQuery = query + where + $" order by {textoSeleccionado};";
            }

            formClientes.ds.Tables["cliente"].Clear();
            formClientes.iniciaDTG();

            formClientes.BringToFront();
        }
        private bool todosVacios()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
                {
                    return false;
                }
            }
            return true;
        }

        private void FormFiltro_FormClosing(object sender, FormClosingEventArgs e)
        {
            formClientes.actualQuery = FormClientes.defaultQuery;

            formClientes.ds.Tables["cliente"].Clear();
            formClientes.iniciaDTG();
        }
    }
}
