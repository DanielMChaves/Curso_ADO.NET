using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnADO.NET
{
    class Update
    {

        /*
         * EJECUCIÓN DE UN 'UPDATE'
         */
        public static void UpdateData(SqlConnection conexion)
        {
            Console.WriteLine("[INFO]: Función 'UpdateData()': Inicio\n");

            try
            {
                // (2) Abrimos la Conexión ...
                Console.WriteLine("(2) Abrimos la Conexión ...\n");
                conexion.Open();

                // (3) Preparamos la Query ...
                Console.WriteLine("(3) Preparamos la Query ...\n");
                string updateString = @"
                update Categories set CategoryName = 'Other'
                where CategoryName = 'Miscellaneous'";

                SqlCommand query = new SqlCommand(updateString);
                query.Connection = conexion;

                // (4) Usamos la Conexión ...
                Console.WriteLine("(4) Usamos la Conexión ...\n");

                //  (4.1) Ejecutamos la Query ...
                Console.WriteLine(" (4.1) Ejecutamos la Query ...\n");
                query.ExecuteNonQuery();
            }
            finally
            {
                // (5) Cerramos la Conexión ...
                Console.WriteLine("(5) Cerramos la Conexión ...\n");
                if (conexion != null) conexion.Close();

                Console.WriteLine("[INFO]: Función 'UpdateData()': Fin\n");
            }
        }

    }
}
