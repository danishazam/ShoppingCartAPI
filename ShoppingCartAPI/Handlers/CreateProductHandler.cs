using MediatR;
using ShoppingCartAPI.Commands;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.Repositories;

namespace ShoppingCartAPI.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository _ProductRepository;

        public CreateProductHandler(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }
        public async Task<Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product(command.Name, command.Price);            ;

            return await _ProductRepository.AddProductAsync(product);
        }
    }
}
