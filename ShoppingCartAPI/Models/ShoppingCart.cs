namespace ShoppingCartAPI.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<CartItem> CartItems { get; set; }

        public ShoppingCart(int id, User user, List<CartItem> cartItems)
        {
            Id = id;
            User = user;
            CartItems = cartItems;
        }
        public ShoppingCart() { }
    }
}
