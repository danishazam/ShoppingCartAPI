using MediatR;
using ShoppingCartAPI.Models;

namespace ShoppingCartAPI.Queries
{
    public class GetProductListQuery : IRequest<List<Product>>
    {
    }
}