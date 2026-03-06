using SimpleApi.Models;

namespace SimpleApi.Services
{
    public class ProductService
    {
        private readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 1000 },
            new Product { Id = 2, Name = "Mouse", Price = 20 }
        };

        public List<Product> GetAll() => _products;

        public Product Add(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
            return product;
        }
    }
}