using System.Data.SqlClient;

namespace AdoSamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string connectionString = "Data Source=.;Initial Catalog=BikeStore;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = ".";
            builder.InitialCatalog = "BikeStore";
            builder.IntegratedSecurity = true;
            builder.TrustServerCertificate = true;

            Console.Write("Enter Category Name : ");
            //string categoryName = Console.ReadLine();

            SqlConnection conn = new SqlConnection(builder.ConnectionString);

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "INSERT INTO sales.stores(store_name,phone,email,street,city,[state],zip_code)" +
            " VALUES(@store_name,@phone,@email,@street,@city,@state,@zip_code)";
            command.Parameters.AddWithValue("@store_name","Digi kala");
            command.Parameters.AddWithValue("@phone","021");
            command.Parameters.AddWithValue("@email","info@digikala.com");
            command.Parameters.AddWithValue("@street","navab");
            command.Parameters.AddWithValue("@city","Tehran");
            command.Parameters.AddWithValue("@state","Tehran");
            command.Parameters.AddWithValue("@zip_code","21546");
            //command.CommandText = "DELETE FROM production.categories WHERE category_id=9";
            //command.CommandText = "UPDATE production.categories SET category_name='Sport Bikes' WHERE category_id=10";
            int rowAffected=0;
           
            conn.Open();
            rowAffected = command.ExecuteNonQuery();
            conn.Close();

            Console.WriteLine($"{rowAffected} row affected");


            //Read
        }
        
    }
}
