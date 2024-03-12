namespace ShoppingCartAPI.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public CartItem(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
        public CartItem() { }
    }
}
