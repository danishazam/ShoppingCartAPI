using MediatR;
using ShoppingCartAPI.Models;

namespace ShoppingCartAPI.Commands
{
    public class CreateProductCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public CreateProductCommand(string name, decimal price)
        {
            Name = name;
            Price = price;            
        }        
    }
}
