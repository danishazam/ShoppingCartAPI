namespace ShoppingCartAPI.Models
{
    public class CheckedOutItem
    {
        public CartItem CartItem { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountedPrice { get; set; }
        public CheckedOutItem(CartItem cartItem, decimal price, decimal discount, decimal discountedPrice)
        {
            CartItem = cartItem;
            Price = price;
            Discount = discount;
            DiscountedPrice = discountedPrice;
        }
    }
}
