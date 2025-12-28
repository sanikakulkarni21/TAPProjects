using MySql.Data.MySqlClient;
using productCatalogMVC.Models;
using productCatalogMVC.Repositories.Interfaces;

namespace productCatalogMVC.Repositories.Implementations
{
    public class CartRepository : ICartRepository
    {
        private readonly string _conn;

        public CartRepository(string conn)
        {
            _conn = conn;
        }

        public List<CartItem> GetCartItems()
        {
            List<CartItem> items = new();

            using MySqlConnection con = new(_conn);
            con.Open();

            string query = @"SELECT c.Id, c.ProductId, c.Quantity,
                             p.Name, p.Price
                             FROM CartItem c
                             JOIN Products p ON c.ProductId = p.Id";

            MySqlCommand cmd = new(query, con);
            var r = cmd.ExecuteReader();

            while (r.Read())
            {
                items.Add(new CartItem
                {
                    Id = r.GetInt32("Id"),
                    ProductId = r.GetInt32("ProductId"),
                    Quantity = r.GetInt32("Quantity"),
                    Product = new Products
                    {
                        Name = r.GetString("Name"),
                        Price = r.GetDecimal("Price")
                    }
                });
            }
            return items;
        }

        public void AddToCart(int productId)
        {
            using MySqlConnection con = new(_conn);
            con.Open();

            string query = "INSERT INTO CartItem(ProductId, Quantity) VALUES(@pid,1)";
            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@pid", productId);
            cmd.ExecuteNonQuery();
        }
    }
}
