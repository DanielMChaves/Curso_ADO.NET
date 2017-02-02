using System;
using System.Data.SqlClient;

namespace LearnADO.NET
{
    class DataBaseController
    {
        static SqlConnection conexion;

        public DataBaseController()
        {
            // (1) Creamos la Conexión ...
            Console.WriteLine("(1) Creamos la Conexión ...\n");
            conexion = new SqlConnection(
                "Data Source=.\\sqlexpress;Initial Catalog=wingtiptoys;Integrated Security=SSPI");
        }
        
        public static void Main(string[] args)
        {

            DataBaseController controller = new DataBaseController();
            
            Console.WriteLine("[INFO]: Categorías antes de insertar\n");

            // Obtenemos las categorías
            Query.GetCategoriesNames(conexion);

            // Ejecutamos el método de inserción
            Insert.InsertData(conexion);
            Console.WriteLine("[INFO]: Categorías después de insertar\n");

            // Obtenemos las categorías
            Query.GetCategoriesNames(conexion);

            // Ejecutamos el método de actualizar
            Update.UpdateData(conexion);
            
            Console.WriteLine("[INFO]: Categorías después de actualizar\n");
            Query.GetCategoriesNames(conexion);

            // Ejecutamos el método de eliminación
            Delete.DeleteData(conexion);
            Console.WriteLine("[INFO]: Categorías después de eliminar\n");

            // Obtenemos las categorías
            Query.GetCategoriesNames(conexion);

            // Obtenemos el número de categorias
            int numberOfRecords = Query.GetNumberCategories(conexion);
            
            Console.WriteLine("Número de Categorías: {0}\n", numberOfRecords);

            // Obtenemos todos los productos con toda su información
            Console.WriteLine("[INFO]: Todos los productos\n");
            Query.GetProductsAll(conexion);

            // Obtenemos todos los productos con ID de categoria 5
            Console.WriteLine("[INFO]: Todos los productos con ID de categoria 5\n");
            Query.GetProductsByCategotyID(conexion, 5);

            // Obtenemos el Top 10 de los productos más caros
            Console.WriteLine("[INFO]: Top 10 de los productos más caros\n");
            Query.GetTop10ExpensiveProducts(conexion);

            // Obtenemos el producto más caro con ID de categoria 1
            Console.WriteLine("[INFO]: El producto más caro con ID de categoria 1\n");
            Query.GetExpensiveProductByCategory(conexion, 1);

            Console.WriteLine("Fin");
            Console.Read();
        }
    }
}
