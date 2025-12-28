using MySql.Data.MySqlClient;
using productCatalogMVC.Models;
using productCatalogMVC.Repositories.Interfaces;

namespace productCatalogMVC.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _conn;

        public ProductRepository(string conn)
        {
            _conn = conn;
        }

        public List<Products> GetAllProducts()
        {
            List<Products> list = new();

            using MySqlConnection con = new(_conn);
            con.Open();

            string query = "SELECT * FROM Products";
            MySqlCommand cmd = new(query, con);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Products
                {
                    Id = reader.GetInt32("Id"),
                    Name = reader.GetString("Name"),
                    Description = reader.GetString("Description"),
                    Price = reader.GetDecimal("Price"),
                    ImageUrl = reader.GetString("ImageUrl")
                });
            }
            return list;
        }

        public Products GetProductById(int id)
        {
            using MySqlConnection con = new(_conn);
            con.Open();

            string query = "SELECT * FROM Products WHERE Id=@id";
            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@id", id);

            var r = cmd.ExecuteReader();
            if (r.Read())
            {
                return new Products
                {
                    Id = r.GetInt32("Id"),
                    Name = r.GetString("Name"),
                    Description = r.GetString("Description"),
                    Price = r.GetDecimal("Price"),
                    ImageUrl = r.GetString("ImageUrl")
                };
            }
            return null;
        }
    }
}
