using MediatR;
using ShoppingCartAPI.Models;

namespace ShoppingCartAPI.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
