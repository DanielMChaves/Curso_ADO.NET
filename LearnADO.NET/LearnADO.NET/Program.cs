using System;
using System.Data.SqlClient;

namespace LearnADO.NET
{
    class DataBaseController
    {
        SqlConnection conexion;

        public DataBaseController()
        {
            // (1) Creamos la Conexión ...
            Console.WriteLine("(1) Creamos la Conexión ...\n");
            conexion = new SqlConnection(
                "Data Source=.\\sqlexpress;Initial Catalog=wingtiptoys;Integrated Security=SSPI");
        }

        /*
         * EJECUCIÓN DE UNA CONSULTA
         */
        public void ReadData()
        {
            Console.WriteLine("[INFO]: Función 'ReadData()': Inicio\n");

            SqlDataReader reader = null;

            try
            {
                // (2) Abrimos la Conexión ...
                Console.WriteLine("(2) Abrimos la Conexión ...\n");
                conexion.Open();

                // (3) Preparamos la Query ...
                Console.WriteLine("(3) Preparamos la Query ...\n");
                SqlCommand query = new SqlCommand("select CategoryName from Categories", conexion);

                // (4) Usamos la Conexión ...
                Console.WriteLine("(4) Usamos la Conexión ...\n");

                //  (4.1) Ejecutamos la Query ...
                Console.WriteLine(" (4.1) Ejecutamos la Query ...\n");
                reader = query.ExecuteReader();

                //  (4.2) Imprimimos los Resultados ...
                Console.WriteLine(" (4.2) Imprimimos los Resultados ...\n");
                while (reader.Read())
                {
                    Console.WriteLine(reader[0]);
                }
                Console.WriteLine();

            }
            finally
            {
                //  (4.3) Cerramos el Lector ...
                Console.WriteLine(" (4.3) Cerramos el Lector ...\n");
                if (reader != null) reader.Close();

                // (5) Cerramos la Conexión ...
                Console.WriteLine("(5) Cerramos la Conexión ...\n");
                if (conexion != null) conexion.Close();

                Console.WriteLine("[INFO]: Función 'ReadData()': Fin\n");
            }
        }

        /// <summary>
        /// use ExecuteNonQuery method for Insert
        /// </summary>
        public void Insertdata()
        {
            try
            {
                // Open the connection
                conexion.Open();

                // prepare command string
                string insertString = @"
                 insert into Categories
                 (CategoryName, Description)
                 values ('Miscellaneous', 'Whatever doesn''t fit elsewhere')";

                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(insertString, conexion);

                // 2. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();
            }
            finally
            {
                // Close the connection
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        /// <summary>
        /// use ExecuteNonQuery method for Update
        /// </summary>
        public void UpdateData()
        {
            try
            {
                // Open the connection
                conexion.Open();

                // prepare command string
                string updateString = @"
                update Categories
                set CategoryName = 'Other'
                where CategoryName = 'Miscellaneous'";

                // 1. Instantiate a new command with command text only
                SqlCommand cmd = new SqlCommand(updateString);

                // 2. Set the Connection property
                cmd.Connection = conexion;

                // 3. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();
            }
            finally
            {
                // Close the connection
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        /// <summary>
        /// use ExecuteNonQuery method for Delete
        /// </summary>
        public void DeleteData()
        {
            try
            {
                // Open the connection
                conexion.Open();

                // prepare command string
                string deleteString = @"
                 delete from Categories
                 where CategoryName = 'Other'";

                // 1. Instantiate a new command
                SqlCommand cmd = new SqlCommand();

                // 2. Set the CommandText property
                cmd.CommandText = deleteString;

                // 3. Set the Connection property
                cmd.Connection = conexion;

                // 4. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();
            }
            finally
            {
                // Close the connection
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public static void Main(string[] args)
        {

            DataBaseController controller = new DataBaseController();
            
            Console.WriteLine("[INFO]: Categorías antes de insertar\n");

            // Ejecutamos el método de lectura
            controller.ReadData();

            // Ejecutamos el método de inserción
            controller.Insertdata();
            Console.WriteLine("[INFO]: Categorías después de insertar\n");
            
            // Ejecutamos el método de lectura
            controller.ReadData();

            // Ejecutamos el método de actualizar
            controller.UpdateData();
            
            Console.WriteLine("[INFO]: Categorías después de actualizar\n");
            controller.ReadData();

            // Ejecutamos el método de eliminación
            controller.DeleteData();
            Console.WriteLine("[INFO]: Categorías después de eliminar\n");

            // Ejecutamos el método de lectura
            controller.ReadData();

            Console.WriteLine("Fin");
            Console.Read();
        }
    }
}
