using MediatR;

namespace ShoppingCartAPI.Commands
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }        

        public UpdateProductCommand(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;            
        }
    }
}
