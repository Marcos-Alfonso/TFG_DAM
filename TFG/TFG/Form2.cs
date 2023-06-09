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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            initCitas();

        }

        private void initCitas()
        {
            
            string query = "SELECT fecha, hora, duracion, descripcion FROM cita";
            using (MySqlCommand command = new MySqlCommand(query, Program.conn))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Obtener los valores de la cita
                        DateTime fecha = reader.GetDateTime("fecha");
                        TimeSpan hora = reader.GetTimeSpan("hora");
                        int duracion = reader.GetInt32("duracion");
                        float duracionEnHoras = duracion / 60.0f;
                        string descripcion = reader.GetString("descripcion");

                        DateTime fechaYHora = fecha.Date.AddTicks(hora.Ticks);

                        // Crear un nuevo evento en el calendario
                        Calendar.NET.CustomEvent e = new Calendar.NET.CustomEvent();
                        e.Date = fechaYHora;
                        e.EventLengthInHours = duracionEnHoras;
                        e.EventText = descripcion;
                        
                        // Agregar el evento al calendario
                        calendar1.AddEvent(e);

                        
                    }
                }
            }

        }

        private void calendar1_Click(object sender, EventArgs e)
        {

        }
    }
}
