using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnADO.NET
{
    class Insert
    {

        /*
         * EJECUCIÓN DE UN 'INSERT'
         */
        public static void InsertData(SqlConnection conexion)
        {
            Console.WriteLine("[INFO]: Función 'InsertData()': Inicio\n");

            try
            {
                // (2) Abrimos la Conexión ...
                Console.WriteLine("(2) Abrimos la Conexión ...\n");
                conexion.Open();

                // (3) Preparamos la Query ...
                Console.WriteLine("(3) Preparamos la Query ...\n");
                string insertString = @"
                 insert into Categories (CategoryName, Description)
                 values ('Miscellaneous', 'Whatever doesn''t fit elsewhere')";

                SqlCommand query = new SqlCommand(insertString, conexion);

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

                Console.WriteLine("[INFO]: Función 'InsertData()': Fin\n");
            }
        }

    }
}
