using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnADO.NET
{
    class Query
    {

        /*
         * Obtener los nombres de todas las categorías
         */
        public static void GetCategoriesNames(SqlConnection conexion)
        {
            Console.WriteLine("[INFO]: Función 'GetCategoriesNames()': Inicio\n");

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

                Console.WriteLine("[INFO]: Función 'GetCategoriesNames()': Fin\n");
            }
        }

        /*
         * Top 10 de los productos más caros (StoredProcedure)
         */
        public static void GetExpensiveProductByCategory(SqlConnection conexion, int category)
        {
            Console.WriteLine("[INFO]: Función 'GetExpensiveProductByCategory()': Inicio\n");

            SqlDataReader reader = null;

            try
            {
                // (2) Abrimos la Conexión ...
                Console.WriteLine("(2) Abrimos la Conexión ...\n");
                conexion.Open();

                // (3) Preparamos la Query ...
                Console.WriteLine("(3) Preparamos la Query ...\n");
                SqlCommand query = new SqlCommand("ExpensiveProductByCategory", conexion);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@ID", category));

                // (4) Usamos la Conexión ...
                Console.WriteLine("(4) Usamos la Conexión ...\n");

                //  (4.1) Ejecutamos la Query ...
                Console.WriteLine(" (4.1) Ejecutamos la Query ...\n");
                reader = query.ExecuteReader();

                //  (4.2) Imprimimos los Resultados ...
                Console.WriteLine(" (4.2) Imprimimos los Resultados ...\n");
                while (reader.Read())
                {

                    int productID = (int)reader["ProductID"];
                    string productName = (string)reader["ProductName"];
                    string description = (string)reader["Description"];
                    string imagePath = (string)reader["ImagePath"];
                    double unitPrice = (double)reader["UnitPrice"];
                    int categoryID = (int)reader["CategoryID"];

                    Console.WriteLine("ProductID: {0,-5}", productID);
                    Console.WriteLine("ProductName: {0,-20}", productName);
                    Console.WriteLine("Description: {0,-100}", description);
                    Console.WriteLine("ImagePath: {0,-20}", imagePath);
                    Console.WriteLine("UnitPrice: {0,-6}", unitPrice);
                    Console.WriteLine("CategoryID: {0,-5}", categoryID);
                    Console.WriteLine();

                }
                Console.WriteLine();

            }
            catch
            {
                Console.WriteLine("[ERROR]: ¿Has creado el procedimiento en la Base de Datos?\n");
            }
            finally
            {
                //  (4.3) Cerramos el Lector ...
                Console.WriteLine(" (4.3) Cerramos el Lector ...\n");
                if (reader != null) reader.Close();

                // (5) Cerramos la Conexión ...
                Console.WriteLine("(5) Cerramos la Conexión ...\n");
                if (conexion != null) conexion.Close();

                Console.WriteLine("[INFO]: Función 'GetExpensiveProductByCategory()': Fin\n");
            }
        }

        /*
         * Obtener número de categorías
         */
        public static int GetNumberCategories(SqlConnection conexion)
        {
            Console.WriteLine("[INFO]: Función 'GetNumberOfRecords()': Inicio\n");
            int count = -1;

            try
            {
                // (2) Abrimos la Conexión ...
                Console.WriteLine("(2) Abrimos la Conexión ...\n");
                conexion.Open();

                // (3) Preparamos la Query ...
                Console.WriteLine("(3) Preparamos la Query ...\n");
                SqlCommand query = new SqlCommand("select count(*) from Categories", conexion);

                // (4) Usamos la Conexión ...
                Console.WriteLine("(4) Usamos la Conexión ...\n");

                //  (4.1) Ejecutamos la Query ...
                Console.WriteLine(" (4.1) Ejecutamos la Query ...\n");
                count = (int)query.ExecuteScalar();
            }
            finally
            {
                // (5) Cerramos la Conexión ...
                Console.WriteLine("(5) Cerramos la Conexión ...\n");
                if (conexion != null) conexion.Close();

                Console.WriteLine("[INFO]: Función 'GetNumberOfRecords()': Fin\n");
            }
            return count;
        }

        /*
         * Obtener todos los productos
         */
        public static void GetProductsAll(SqlConnection conexion)
        {
            Console.WriteLine("[INFO]: Función 'GetProductsAll()': Inicio\n");

            SqlDataReader reader = null;

            try
            {
                // (2) Abrimos la Conexión ...
                Console.WriteLine("(2) Abrimos la Conexión ...\n");
                conexion.Open();

                // (3) Preparamos la Query ...
                Console.WriteLine("(3) Preparamos la Query ...\n");
                SqlCommand query = new SqlCommand("select * from Products", conexion);

                // (4) Usamos la Conexión ...
                Console.WriteLine("(4) Usamos la Conexión ...\n");

                //  (4.1) Ejecutamos la Query ...
                Console.WriteLine(" (4.1) Ejecutamos la Query ...\n");
                reader = query.ExecuteReader();

                //  (4.2) Imprimimos los Resultados ...
                Console.WriteLine(" (4.2) Imprimimos los Resultados ...\n");
                while (reader.Read())
                {

                    int productID = (int)reader["ProductID"];
                    string productName = (string)reader["ProductName"];
                    string description = (string)reader["Description"];
                    string imagePath = (string)reader["ImagePath"];
                    double unitPrice = (double)reader["UnitPrice"];
                    int categoryID = (int)reader["CategoryID"];

                    Console.WriteLine("ProductID: {0,-5}", productID);
                    Console.WriteLine("ProductName: {0,-20}", productName);
                    Console.WriteLine("Description: {0,-100}", description);
                    Console.WriteLine("ImagePath: {0,-20}", imagePath);
                    Console.WriteLine("UnitPrice: {0,-6}", unitPrice);
                    Console.WriteLine("CategoryID: {0,-5}", categoryID);
                    Console.WriteLine();

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

                Console.WriteLine("[INFO]: Función 'GetProductsAll()': Fin\n");
            }
        }

        /*
         * Obtener todos los productos por el ID de categoría
         */
        public static void GetProductsByCategotyID(SqlConnection conexion, int category)
        {
            Console.WriteLine("[INFO]: Función 'GetProductsByCategotyID()': Inicio\n");

            SqlDataReader reader = null;

            try
            {
                // (2) Abrimos la Conexión ...
                Console.WriteLine("(2) Abrimos la Conexión ...\n");
                conexion.Open();

                // (3) Preparamos la Query ...
                Console.WriteLine("(3) Preparamos la Query ...\n");
                SqlCommand query = new SqlCommand(
                    "select * from Products where CategoryID = @ID", conexion);

                // (4) Usamos la Conexión ...
                Console.WriteLine("(4) Usamos la Conexión ...\n");

                //  (4.0) Comprobamos y añadimos los parámetros de la Query ...
                Console.WriteLine(" (4.0) Comprobamos y añadimos los parámetros de la Query ...\n");
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@ID";
                param.Value = category;

                query.Parameters.Add(param);

                //  (4.1) Ejecutamos la Query ...
                Console.WriteLine(" (4.1) Ejecutamos la Query ...\n");
                reader = query.ExecuteReader();

                //  (4.2) Imprimimos los Resultados ...
                Console.WriteLine(" (4.2) Imprimimos los Resultados ...\n");
                while (reader.Read())
                {

                    int productID = (int)reader["ProductID"];
                    string productName = (string)reader["ProductName"];
                    string description = (string)reader["Description"];
                    string imagePath = (string)reader["ImagePath"];
                    double unitPrice = (double)reader["UnitPrice"];
                    int categoryID = (int)reader["CategoryID"];

                    Console.WriteLine("ProductID: {0,-5}", productID);
                    Console.WriteLine("ProductName: {0,-20}", productName);
                    Console.WriteLine("Description: {0,-100}", description);
                    Console.WriteLine("ImagePath: {0,-20}", imagePath);
                    Console.WriteLine("UnitPrice: {0,-6}", unitPrice);
                    Console.WriteLine("CategoryID: {0,-5}", categoryID);
                    Console.WriteLine();

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

                Console.WriteLine("[INFO]: Función 'GetProductsByCategotyID()': Fin\n");
            }
        }

        /*
         * Top 10 de los productos más caros (StoredProcedure)
         */
        public static void GetTop10ExpensiveProducts(SqlConnection conexion)
        {
            Console.WriteLine("[INFO]: Función 'GetTop10ExpensiveProducts()': Inicio\n");

            SqlDataReader reader = null;

            try
            {
                // (2) Abrimos la Conexión ...
                Console.WriteLine("(2) Abrimos la Conexión ...\n");
                conexion.Open();

                // (3) Preparamos la Query ...
                Console.WriteLine("(3) Preparamos la Query ...\n");
                SqlCommand query = new SqlCommand("TenMostExpensiveProducts", conexion);
                query.CommandType = CommandType.StoredProcedure;

                // (4) Usamos la Conexión ...
                Console.WriteLine("(4) Usamos la Conexión ...\n");

                //  (4.1) Ejecutamos la Query ...
                Console.WriteLine(" (4.1) Ejecutamos la Query ...\n");
                reader = query.ExecuteReader();

                //  (4.2) Imprimimos los Resultados ...
                Console.WriteLine(" (4.2) Imprimimos los Resultados ...\n");
                while (reader.Read())
                {

                    int productID = (int)reader["ProductID"];
                    string productName = (string)reader["ProductName"];
                    string description = (string)reader["Description"];
                    string imagePath = (string)reader["ImagePath"];
                    double unitPrice = (double)reader["UnitPrice"];
                    int categoryID = (int)reader["CategoryID"];

                    Console.WriteLine("ProductID: {0,-5}", productID);
                    Console.WriteLine("ProductName: {0,-20}", productName);
                    Console.WriteLine("Description: {0,-100}", description);
                    Console.WriteLine("ImagePath: {0,-20}", imagePath);
                    Console.WriteLine("UnitPrice: {0,-6}", unitPrice);
                    Console.WriteLine("CategoryID: {0,-5}", categoryID);
                    Console.WriteLine();

                }
                Console.WriteLine();

            }
            catch
            {
                Console.WriteLine("[ERROR]: ¿Has creado el procedimiento en la Base de Datos?\n");
            }
            finally
            {
                //  (4.3) Cerramos el Lector ...
                Console.WriteLine(" (4.3) Cerramos el Lector ...\n");
                if (reader != null) reader.Close();

                // (5) Cerramos la Conexión ...
                Console.WriteLine("(5) Cerramos la Conexión ...\n");
                if (conexion != null) conexion.Close();

                Console.WriteLine("[INFO]: Función 'GetTop10ExpensiveProducts()': Fin\n");
            }
        }

    }
}
