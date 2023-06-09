using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG
{
    public partial class FormCalendario : Form
    {
        String query = "SELECT c.id, c.idUsuario, cl.dni, c.fecha, c.hora, c.duracion, c.descripcion, cl.nombre AS nombreCliente FROM cita c JOIN cliente cl ON c.idCliente = cl.id order by c.fecha";
        public FormCalendario()
        {
            InitializeComponent();
            initializeList();
            initializeHelp();
            initializeComboUser();

        }
        int id = 0;
        public FormCalendario(int id)
        {
            InitializeComponent();
             query = "SELECT c.id, c.idUsuario, cl.dni, c.fecha, c.hora, c.duracion, c.descripcion, cl.nombre AS nombreCliente FROM cita c JOIN cliente cl ON c.idCliente = cl.id where cl.id = "+id+" order by c.fecha";
            this.id = id;
            initializeList();
            initializeHelp();
            initializeComboUser();
        }


        private void initializeComboUser()
        {
            string query = "SELECT * FROM usuario";

            using (MySqlCommand command = new MySqlCommand(query, Program.conn))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cbUsuario.Items.Add(new { Value = reader.GetString(0), Text = reader.GetString(1) });
                    }
                }
            }
            cbUsuario.DisplayMember = "Text";

            foreach (dynamic item in cbUsuario.Items)
            {
                if (item.Value == Program.userId)
                {
                    cbUsuario.SelectedItem = item;
                    break;
                }
            }

        }

        private void initializeHelp()
        {
            string query = "SELECT nombre, dni FROM cliente";

            using (MySqlCommand command = new MySqlCommand(query, Program.conn))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        txNombre.AutoCompleteCustomSource.Add(reader.GetString(0) + " / " + reader.GetString(1));
                    }
                }
            }
        }
        private void initializeList()
        {
            listView1.View = View.Details;


            // Agregar las columnas necesarias al ListView
            ColumnHeader e = listView1.Columns.Add("Hora");
            //e.Tag = "Oculta";
            //e.Width = 0;

            e = listView1.Columns.Add("id");
            e.Tag = "Oculta";
            e.Width = 0;

            e = listView1.Columns.Add("idUsuario");
            e.Tag = "Oculta";
            e.Width = 0;

            listView1.Columns.Add("Cliente");
            listView1.Columns.Add("DNI");

            e = listView1.Columns.Add("Fecha");
            e.Tag = "Oculta";
            e.Width = 0;


            listView1.Columns.Add("Duración");

            e = listView1.Columns.Add("Descripción");
            e.Tag = "Oculta";
            e.Width = 0;

            loadItemsList();

            listView1.ColumnWidthChanging += ListView1_ColumnWidthChanging;

            listView1.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.Columns[4].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.Columns[6].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);


        }
        List<Calendar.NET.IEvent> listaEventos = new List<Calendar.NET.IEvent>();
        private void loadItemsList()
        {
            listView1.Items.Clear();

            foreach (Calendar.NET.IEvent item in listaEventos)
            {
                calendar1.RemoveEvent(item);
            }

            listaEventos = new List<Calendar.NET.IEvent>();

            using (MySqlCommand command = new MySqlCommand(query,  Program.conn))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    DateTime currentDate = DateTime.MinValue;
                    ListViewGroup currentGroup = null;

                    while (reader.Read())
                    {
                        String id = reader.GetString("id");
                        String idUsuario = reader.GetString("idUsuario");
                        string dniCliente = reader.GetString("dni");
                        DateTime fecha = reader.GetDateTime("fecha");
                        TimeSpan hora = reader.GetTimeSpan("hora");
                        int duracion = reader.GetInt32("duracion");
                        string descripcion = reader.GetString("descripcion");
                        string nombre = reader.GetString("nombreCliente");


                        // Crear un ListViewItem con los valores obtenidos
                        ListViewItem item = new ListViewItem(hora.ToString(@"hh\:mm"));

                        item.SubItems.Add(id);
                        item.SubItems.Add(idUsuario.ToString());
                        item.SubItems.Add(nombre);
                        item.SubItems.Add(dniCliente);
                        item.SubItems.Add(fecha.ToString("dd/MM/yyyy"));
                        //item.SubItems.Add(hora.ToString("HH:mm"));

                        item.SubItems.Add(duracion.ToString());
                        item.SubItems.Add(descripcion);

                        // Verificar si la fecha es diferente a la anterior
                        if (fecha.Date != currentDate.Date)
                        {
                            // Crear un nuevo grupo en el ListView para el nuevo día
                            currentGroup = new ListViewGroup(fecha.ToString("dd/MM/yyyy"));
                            listView1.Groups.Add(currentGroup);
                            currentDate = fecha.Date;
                        }

                        // Agregar el ListViewItem al ListView y asignarlo al grupo correspondiente
                        item.Group = currentGroup;
                        if (idUsuario.Equals(Program.userId))
                        {
                            item.Font = new Font(listView1.Font, FontStyle.Bold);
                            item.ForeColor = Settings1.Default.myColor;
                        }
                        listView1.Items.Add(item);


                        //añade a calendario
                        DateTime fechaYHora = fecha.Date.AddTicks(hora.Ticks);
                        float duracionEnHoras = duracion / 60.0f;

                        Calendar.NET.CustomEvent e = new Calendar.NET.CustomEvent();
                        e.Date = fechaYHora;
                        e.EventLengthInHours = duracionEnHoras;
                        e.EventText = nombre;
                        if (idUsuario.Equals(Program.userId))
                        {
                            e.EventColor = Settings1.Default.myColor;
                            e.EventFont = new Font(listView1.Font, FontStyle.Bold);
                        }

                        calendar1.AddEvent(e);
                        listaEventos.Add(e);
                    }
                }
            }
            calendar1.CalendarDate = DateTime.Now;

            if (listView1.Items.Count > 0)
            {
                listView1.Items[0].Selected = true;
                listView1.Items[0].Focused = true;
                listView1.Select();
            }

        }
        private void ListView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            ColumnHeader columnHeader = listView1.Columns[e.ColumnIndex];
            if (columnHeader.Tag != null && columnHeader.Tag.ToString() == "Oculta")
            {
                e.NewWidth = 0; // Establecer el nuevo ancho a cero para ocultar la columna
                e.Cancel = true; // Cancelar el cambio de ancho de columna
            }
        }


        private void otroSeleccionado(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem v = listView1.SelectedItems[0];
                txNombre.Text = v.SubItems[3].Text;
                tbDni.Text = v.SubItems[4].Text;
                //fecha y hora

                DateTime fecha = DateTime.ParseExact(v.SubItems[5].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime hora = DateTime.ParseExact(v.Text, "HH:mm", CultureInfo.InvariantCulture);

                //DateTime fechaHora = new DateTime(fecha.Year, fecha.Month, fecha.Day, hora.Hour, hora.Minute, hora.Second);

                foreach (dynamic item in cbUsuario.Items)
                {
                    if (item.Value == v.SubItems[2].Text)
                    {
                        cbUsuario.SelectedItem = item;
                        break;
                    }
                }

                dtFecha.Value = fecha;
                dtHora.Value = hora;

                tbDuracion.Value = Int32.Parse(v.SubItems[6].Text);
                rtDescripcion.Text = v.SubItems[7].Text;

                txNombre.Enabled = false;
                cbUsuario.Enabled = false;
                dtFecha.Enabled = false;
                dtHora.Enabled = false;
                tbDuracion.Enabled = false;
                rtDescripcion.Enabled = false;

                btAceptar.Visible = false;
            }

        }

        private void cambioNombre(object sender, EventArgs e)
        {
            if (obtenerSlash(txNombre.Text) != string.Empty)
            {
                tbDni.Text = obtenerSlash(txNombre.Text);
                txNombre.Text = borrarSlash(txNombre.Text);
            }


        }
        public string obtenerSlash(string texto)
        {
            int indiceSlash = texto.IndexOf(" / ");
            if (indiceSlash != -1 && indiceSlash < texto.Length - 1)
            {
                return texto.Substring(indiceSlash + 3);
            }
            return string.Empty;
        }
        public string borrarSlash(string texto)
        {
            int indiceSlash = texto.IndexOf(" / ");
            if (indiceSlash != -1)
            {
                return texto.Substring(0, indiceSlash);
            }
            return texto;
        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            listView1.SelectedItems.Clear();

            txNombre.Text = "";
            tbDni.Text = "";
            cbUsuario.SelectedValue = Program.userId;
            dtFecha.Value = DateTime.Now;
            dtHora.Value = DateTime.Now;
            tbDuracion.Value = 30;
            rtDescripcion.Text = "";

            if (id != 0)
            {
                cargaNombre();
            }

            txNombre.Enabled = true;
            cbUsuario.Enabled = true;
            dtFecha.Enabled = true;
            dtHora.Enabled = true;
            tbDuracion.Enabled = true;
            rtDescripcion.Enabled = true;

            btAceptar.Visible = true;

            foreach (dynamic item in cbUsuario.Items)
            {
                if (item.Value == Program.userId)
                {
                    cbUsuario.SelectedItem = item;
                    break;
                }
            }
        }

        private void cargaNombre()
        {
            string query = "SELECT Nombre, DNI FROM cliente WHERE id = @id";

            using (MySqlCommand command = new MySqlCommand(query, Program.conn))
            {
                command.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string nombre = reader.GetString("Nombre");
                        string dni = reader.GetString("DNI");

                        txNombre.Text = nombre;
                        tbDni.Text = dni;
                    }
                }
            }
        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem i = listView1.SelectedItems[0];

                String nombre = i.SubItems[3].Text;
                String fecha = i.SubItems[5].Text;
                String hora = i.Text;

                if (MessageBox.Show($"Deseas eliminar cita con  {nombre} en fecha {fecha} {hora} ", "Confirmación eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string query = $"DELETE FROM cita WHERE id = '{i.SubItems[1].Text}'";


                    using (MySqlCommand command = new MySqlCommand(query, Program.conn))
                    {
                        //command.Parameters.AddWithValue("@id", i.SubItems[1].Text);

                        int num = command.ExecuteNonQuery();
                    }
                }
                initializeList();
            }

        }

        private void pdMod_Click(object sender, EventArgs e)
        {
            txNombre.Enabled = true;
            cbUsuario.Enabled = true;
            dtFecha.Enabled = true;
            dtHora.Enabled = true;
            tbDuracion.Enabled = true;
            rtDescripcion.Enabled = true;

            btAceptar.Visible = true;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbDni.Text))
            {

                return;
            }
            if (listView1.SelectedItems.Count > 0)
            {
                modificaCita();
            }
            else
            {
                insertaCita();
            }
        }

        private void modificaCita()
        {
            //caso en el que se esta introduciendo un cliente.
            string sql = "UPDATE cita SET idUsuario = @idUsuario, idCliente = @idCliente, fecha = @fecha, hora = @hora, duracion = @duracion, descripcion = @descripcion WHERE id = @id";

            try
            {
                int idCliente = idFromDNI();
                using (MySqlCommand command = new MySqlCommand(sql, Program.conn))
                {
                    String selectedValue = ((dynamic)cbUsuario.SelectedItem).Value;
                    String id = listView1.SelectedItems[0].SubItems[1].Text;

                    // Establecer los parámetros con los valores a insertar
                    command.Parameters.AddWithValue("@idUsuario", selectedValue);
                    command.Parameters.AddWithValue("@idCliente", idCliente);
                    //command.Parameters.AddWithValue("@dniCliente", tbDni.Text);
                    command.Parameters.AddWithValue("@fecha", dtFecha.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@hora", dtHora.Text);
                    command.Parameters.AddWithValue("@duracion", tbDuracion.Value);
                    command.Parameters.AddWithValue("@descripcion", rtDescripcion.Text);
                    command.Parameters.AddWithValue("@id", id);

                    int filas = command.ExecuteNonQuery();

                    // Verificar si se modificadas filas correctamente
                    if (filas > 0)
                    {
                        loadItemsList();
                        seleccionaItem(id);
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido modificar cita. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void seleccionaItem(string id)
        {

            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[1].Text == id)
                {
                    item.Selected = true;
                    item.Focused = true;
                    listView1.Select();
                }
            }

        }

        private void insertaCita()
        {
            //caso en el que se esta introduciendo un cliente.
            string sql = "INSERT INTO cita (id, idUsuario,idCliente, fecha, hora, duracion, descripcion) " +
            "VALUES (@id, @idUsuario,@idCLiente, @fecha, @hora, @duracion, @descripcion)";
            int idCliente = idFromDNI();
           

                using (MySqlCommand command = new MySqlCommand(sql, Program.conn))
                {
                    String selectedValue = ((dynamic)cbUsuario.SelectedItem).Value;
                    string id = generaId();
                    // Establecer los parámetros con los valores a insertar
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@idUsuario", selectedValue);
                    command.Parameters.AddWithValue("@idCliente", idCliente);
                    //command.Parameters.AddWithValue("@dniCliente", tbDni.Text);
                    command.Parameters.AddWithValue("@fecha", dtFecha.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@hora", dtHora.Text);
                    command.Parameters.AddWithValue("@duracion", tbDuracion.Value);
                    command.Parameters.AddWithValue("@descripcion", rtDescripcion.Text);

                    int filasInsertadas = command.ExecuteNonQuery();

                    // Verificar si se insertaron filas correctamente
                    if (filasInsertadas > 0)
                    {
                        loadItemsList();
                        seleccionaItem(id);
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido introducir cita. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private int idFromDNI()
        {

            int idCliente = 0;
            string query = "SELECT id FROM cliente WHERE DNI = @dni";

            using (MySqlCommand command = new MySqlCommand(query, Program.conn))
            {
                command.Parameters.AddWithValue("@dni", tbDni.Text);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        idCliente = reader.GetInt32("id");
                    }
                }
            }

            return idCliente;
        }

        public string generaId()
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder sb = new StringBuilder();
            Random random = new Random();

            do
            {
                for (int i = 0; i < 9; i++)
                {
                    int index = random.Next(caracteres.Length);
                    sb.Append(caracteres[index]);
                }

            } while (idExist(sb.ToString()));

            return sb.ToString();
        }
        public static bool idExist(String id)
        {
            string query = $"SELECT COUNT(*) FROM cita WHERE id = '{id}'";
            int count;

            using (MySqlCommand command = new MySqlCommand(query, Program.conn))
            {
                count = Convert.ToInt32(command.ExecuteScalar());
            }

            if (count > 0)
            {
                return true;
            }
            return false;
        }
    }

}
