using MediatR;

namespace ShoppingCartAPI.Commands
{
    public class DeleteProductCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
