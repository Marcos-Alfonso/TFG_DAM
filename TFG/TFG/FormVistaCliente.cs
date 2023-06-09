using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG
{
    public partial class FormVistaCliente : Form
    {
        public FormVistaCliente()
        {
            InitializeComponent();

            cargaProvincia();
            this.Text = "Alta de cliente";
            tsbMod.Enabled = false;
            toolStripButtonArchivos.Enabled = false;
            tsbCitas.Enabled = false;
            button1.Visible = true;
        }

        int id = 0;
        public FormVistaCliente(int id, bool mod)
        {
            InitializeComponent();

            this.id = id;
            cargaProvincia();
            cargaCliente();
            if (mod)
            {
                iniciaModificar();
            }
            else
            {
                iniciaVisualizar();
            }


        }

        string dniActual = "";
        private void iniciaModificar()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox tb)
                {
                    tb.Enabled = true;
                }

            }
            cbMunicipio.Enabled = cbProvincia.Enabled = true;
            dniActual = tbDni.Text;
            this.Text = "Modificando cliente: " + tbNombre.Text;
            tsbMod.Enabled = false;
            toolStripButtonArchivos.Enabled = false;
            tsbCitas.Enabled = false;
            button1.Visible = true;
        }

        private void iniciaVisualizar()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox tb)
                {
                    tb.Enabled = false;
                }

            }
            cbMunicipio.Enabled = cbProvincia.Enabled = false;
            dniActual = "";
            tsbMod.Enabled = true;
            toolStripButtonArchivos.Enabled = true;
            tsbCitas.Enabled = true;
            button1.Visible = false;
            this.Text = "Visualizando cliente: " + tbNombre.Text;
        }

        private void cargaCliente()
        {

            string query = $"SELECT * FROM cliente WHERE id = {id}";

            using (MySqlCommand command = new MySqlCommand(query, Program.conn))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        string nombre = reader.GetString("Nombre");
                        string dni = reader.GetString("DNI");
                        string direccion = reader.GetString("Direccion");
                        string CD = reader.GetString("Codigo_postal");
                        string telf1 = reader.IsDBNull(reader.GetOrdinal("Telefono1")) ? string.Empty : reader.GetString("Telefono1");
                        string telf2 = reader.IsDBNull(reader.GetOrdinal("Telefono2")) ? string.Empty : reader.GetString("Telefono2");
                        String email = reader.GetString("email");

                        tbNombre.Text = nombre;
                        tbDni.Text = dni;
                        tbDireccion.Text = direccion;
                        tbCD.Text = CD;
                        tbTelf1.Text = telf1;
                        tbTelf2.Text = telf2;
                        tbEmail.Text = email;

                    }
                }
            }
            string carpetaGeneral = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "gestionA");
            string carpetaCliente = Path.Combine(carpetaGeneral, tbDni.Text);
            string rutaFichero = Path.Combine(carpetaCliente, "log.rtf");
            if (Directory.Exists(carpetaCliente) && File.Exists(rutaFichero))
            {
                richTextBox1.LoadFile(rutaFichero);
                richTextBox1.Select(richTextBox1.Text.Length - 1, 0);
                richTextBox1.ScrollToCaret();
            }
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
        private bool ExisteDNI(string dni)
        {
            string query = "SELECT COUNT(*) FROM cliente WHERE DNI = @dni";

            using (MySqlCommand command = new MySqlCommand(query, Program.conn))
            {
                command.Parameters.AddWithValue("@dni", dni);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
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

        private void cbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            var provinciaSeleccionada = (dynamic)cbMunicipio.SelectedItem;
        }

        private void tbTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reiniciaControles();
            String errores = generaErrores();
            if (errores != "")
            {
                MessageBox.Show("Error/es: " + errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String advertencias = generaAdvertencias();
            if (advertencias != "")
            {
                DialogResult result = MessageBox.Show("Se encontraron las siguientes advertencias:" + advertencias + "\n¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                {
                    return;
                }
            }

            if (id == 0 && dniActual == "")
            {
                darAlta();
            }
            else
            {
                darModif();
            }

            iniciaVisualizar();
        }

        private void darModif()
        {

            string nombre = tbNombre.Text;
            string dni = tbDni.Text;
            string direccion = tbDireccion.Text;
            var provinciaSeleccionada = (dynamic)cbProvincia.SelectedItem;
            string idProvincia = provinciaSeleccionada.Value;
            var municipioSeleccionado = (dynamic)cbMunicipio.SelectedItem;
            string idMunicipio = municipioSeleccionado.Value;
            string codigoPostal = tbCD.Text;
            string telefono1 = tbTelf1.Text;
            string telefono2 = tbTelf2.Text;
            string email = tbEmail.Text;

            if (codigoPostal == "") codigoPostal = null;
            if (telefono1 == "") telefono1 = null;
            if (telefono2 == "") telefono2 = null;
            try
            {

            string query = "UPDATE cliente SET Nombre = @nombre, DNI = @dni, Direccion = @direccion, municipio = @idMunicipio, provincia = @idProvincia, Codigo_Postal = @codigoPostal, Telefono1 = @telefono1, Telefono2 = @telefono2, Email = @email "
            + "WHERE id = @id";

                using (MySqlCommand command = new MySqlCommand(query, Program.conn))
                {
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@dni", dni);
                    command.Parameters.AddWithValue("@direccion", direccion);
                    command.Parameters.AddWithValue("@idMunicipio", idMunicipio);
                    command.Parameters.AddWithValue("@idProvincia", idProvincia);
                    command.Parameters.AddWithValue("@codigoPostal", codigoPostal);
                    command.Parameters.AddWithValue("@telefono1", telefono1);
                    command.Parameters.AddWithValue("@telefono2", telefono2);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@id", this.id);

                    command.ExecuteNonQuery();
                }
                if (dni != this.dniActual)
                {

                    string carpetaGeneral = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "gestionA");
                    string carpetaCliente = Path.Combine(carpetaGeneral, this.dniActual);
                    string carpetaClienteNueva = Path.Combine(carpetaGeneral, dni);
                    if (Directory.Exists(carpetaCliente))
                    {
                        Directory.Move(carpetaCliente, carpetaClienteNueva);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar cliente: " + ex.Message);
            }

        }

        private void darAlta()
        {
            string nombre = tbNombre.Text;
            string dni = tbDni.Text;
            string direccion = tbDireccion.Text;
            var provinciaSeleccionada = (dynamic)cbProvincia.SelectedItem;
            string idProvincia = provinciaSeleccionada.Value;
            var municipioSeleccionado = (dynamic)cbMunicipio.SelectedItem;
            string idMunicipio = municipioSeleccionado.Value;
            string codigoPostal = tbCD.Text;
            string telefono1 = tbTelf1.Text;
            string telefono2 = tbTelf2.Text;
            /*
            int telefono2;
            if (!int.TryParse(tbTelf2.Text, out telefono2))
            {
                telefono2 = 0; // Valor predeterminado en caso de ser nulo o no válido
            }
            */
            string email = tbEmail.Text;

            if (codigoPostal == "") codigoPostal = null;
            if (telefono1 == "") telefono1 = null;
            if (telefono2 == "") telefono2 = null;

            try
            {
                string query = "INSERT INTO cliente (Nombre, DNI, Direccion, Municipio, Provincia, Codigo_Postal, Telefono1, Telefono2, Email) VALUES (@nombre, @dni, @direccion, @municipio, @provincia, @codigoPostal, @telefono1, @telefono2, @email)";

                using (MySqlCommand command = new MySqlCommand(query, Program.conn))
                {
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@dni", dni);
                    command.Parameters.AddWithValue("@direccion", direccion);
                    command.Parameters.AddWithValue("@municipio", idMunicipio);
                    command.Parameters.AddWithValue("@provincia", idProvincia);
                    command.Parameters.AddWithValue("@codigoPostal", codigoPostal);
                    command.Parameters.AddWithValue("@telefono1", telefono1);
                    command.Parameters.AddWithValue("@telefono2", telefono2);
                    command.Parameters.AddWithValue("@email", email);

                    command.ExecuteNonQuery();
                }

                using (MySqlCommand command = new MySqlCommand("SELECT id from cliente where dni = @dni", Program.conn))
                {
                    command.Parameters.AddWithValue("@dni", dni);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.id = reader.GetInt32("id");

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al dar de alta al cliente: " + ex.Message);
            }
        }


        private void reiniciaControles()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox textBox)
                {
                    textBox.ForeColor = Color.Black;

                }
                else if (item is ComboBox c)
                {
                    c.ForeColor = Color.Black;
                }
            }
        }

        private string generaErrores()
        {
            string er = "";

            if (tbDni.Text.Length == 0)
            {
                er += "\n   -DNI no puede estar vacío";
                tbDni.ForeColor = Color.Red;
            }
            else if (tbDni.Text != dniActual && ExisteDNI(tbDni.Text))
            {
                er += "\n   -DNI ya existe";
            }
            if (tbNombre.Text.Length == 0)
            {
                er += "\n   -Nombre no puede estar vacío";
                tbNombre.ForeColor = Color.Red;
            }
            if (pruebaProvMuni())
            {
                er += "\n   -Error en la selección de procincia/municipio";
                cbMunicipio.ForeColor = cbProvincia.ForeColor = Color.Red;
            }

            return er;
        }

        private bool pruebaProvMuni()
        {

            var provinciaSeleccionada = (dynamic)cbProvincia.SelectedItem;
            string idProvincia = provinciaSeleccionada.Value;
            var municipioSeleccionado = (dynamic)cbMunicipio.SelectedItem;
            string idMunicipio = municipioSeleccionado.Value;

            string query = $"SELECT COUNT(*) FROM MUNICIPIOS WHERE idProvincia = '{idProvincia}' AND idMunicipio = '{idMunicipio}'";

            using (MySqlCommand command = new MySqlCommand(query, Program.conn))
            {
                int count = Convert.ToInt32(command.ExecuteScalar());

                // Si el resultado es mayor a cero, significa que el municipio pertenece a la provincia
                return !(count > 0);
            }

        }

        private string generaAdvertencias()
        {
            String ad = "";
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            string texto = tbDni.Text;
            if (texto.Length < 9 || (Char.IsLetter(texto[0]) && Char.IsLetter(texto[texto.Length - 1])))
            {
                ad += "\n   -Formato de DNI/CIF/NIE no correcto.";
            }
            if (tbDireccion.Text.Length == 0)
            {
                ad += "\n   -Dirección no completada.";
            }
            if (tbCD.Text.Length == 0)
            {
                ad += "\n   -Codigo Postal no completado.";
            }
            if (tbTelf1.Text.Length == 0 && tbTelf2.Text.Length == 0)
            {
                ad += "\n   -Telefono no completado.";
            }
            if (tbEmail.Text.Length == 0)
            {
                ad += "\n   -Email no completado.";
            }
            else if (string.IsNullOrEmpty(tbEmail.Text) || !Regex.IsMatch(tbEmail.Text, emailPattern))
            {
                ad += "\n   -El formato del email es incorrecto.";
            }
            return ad;
        }

        private void tsbMod_Click(object sender, EventArgs e)
        {
            iniciaModificar();
        }

        private void toolStripButtonArchivos_Click(object sender, EventArgs e)
        {
            FormClienteLog f = new FormClienteLog(tbDni.Text, tbNombre.Text);
            f.ShowDialog();
            string carpetaGeneral = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "gestionA");
            string carpetaCliente = Path.Combine(carpetaGeneral, tbDni.Text);
            string rutaFichero = Path.Combine(carpetaCliente, "log.rtf");
            if (Directory.Exists(carpetaCliente) && File.Exists(rutaFichero))
            {
                richTextBox1.LoadFile(rutaFichero);
                richTextBox1.Select(richTextBox1.Text.Length - 1, 0);
                richTextBox1.ScrollToCaret();
            }
        }

        private void tsbCitas_Click(object sender, EventArgs e)
        {
            FormCalendario f = new FormCalendario(id);
            f.ShowDialog();
        }
    }
}
