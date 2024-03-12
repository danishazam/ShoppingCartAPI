using MediatR;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.Queries;
using ShoppingCartAPI.Repositories;

namespace ShoppingCartAPI.Handlers
{
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, List<Product>>
    {
        private readonly IProductRepository _ProductRepository;

        public GetProductListHandler(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        public async Task<List<Product>> Handle(GetProductListQuery query, CancellationToken cancellationToken)
        {
            return await _ProductRepository.GetProductListAsync();
        }
    }
}
