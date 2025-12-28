using productCatalogMVC.Models;

namespace productCatalogMVC.Repositories.Interfaces
{
    public interface ICartRepository
    {
        List<CartItem> GetCartItems();
        void AddToCart(int productId);
    }
}
