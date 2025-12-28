using productCatalogMVC.Models;

namespace productCatalogMVC.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Products> GetAllProducts();
        Products GetProductById(int id);
    }
}
