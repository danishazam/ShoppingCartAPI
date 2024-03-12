namespace ShoppingCartAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool HasLoyaltyCard { get; set; }

        public User(int userId, string? userName, string? email, string? password, bool hasLoyaltyCard)
        {
            UserId = userId;
            UserName = userName;
            Email = email;
            Password = password;
            HasLoyaltyCard = hasLoyaltyCard;
        }
        public User() { }
    }
}
