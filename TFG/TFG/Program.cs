using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TFG
{
    static class Program
    {
        public static String userId = "";
        public static MySqlConnection conn = new MySqlConnection();
        //public static string user = "";

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new FormClienteLog("AA45m"));
            Application.Run(new FormDBlogin());
            
            if (conn.State == ConnectionState.Open)
            {
                Application.Run(new FormUserLogin());
                if (userId != "")
                {
                    Application.Run(new FormClientes());
                    conn.Close();
                }
            }

        }
    }
}
