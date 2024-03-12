using MediatR;
using ShoppingCartAPI.Commands;
using ShoppingCartAPI.Repositories;

namespace ShoppingCartAPI.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IProductRepository _ProductRepository;

        public DeleteProductHandler(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        public async Task<int> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _ProductRepository.GetProductByIdAsync(command.Id);
            if (product == null)
                return default;

            return await _ProductRepository.DeleteProductAsync(product.Id);
        }
    }
}
