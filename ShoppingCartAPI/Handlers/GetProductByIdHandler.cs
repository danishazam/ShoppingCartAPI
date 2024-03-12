using MediatR;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.Queries;
using ShoppingCartAPI.Repositories;

namespace ShoppingCartAPI.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _ProductRepository;

        public GetProductByIdHandler(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            return await _ProductRepository.GetProductByIdAsync(query.Id);
        }
    }
}
