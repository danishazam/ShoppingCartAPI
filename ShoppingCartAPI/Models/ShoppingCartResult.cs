namespace ShoppingCartAPI.Models
{
    public class ShoppingCartResult
    {
        public decimal TotalCost { get; set; }
        public List<CheckedOutItem> CheckedOutItems { get; set; }

        public ShoppingCartResult(decimal totalCost, List<CheckedOutItem> checkedOutItems)
        {
            TotalCost = totalCost;
            CheckedOutItems = checkedOutItems;
        }
    }
}
