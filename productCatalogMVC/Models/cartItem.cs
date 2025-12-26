namespace productCatalogMVC.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Products Product { get; set; }
    }
}
