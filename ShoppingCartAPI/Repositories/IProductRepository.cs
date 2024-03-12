using ShoppingCartAPI.Models;

namespace ShoppingCartAPI.Repositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProductListAsync();
        public Task<Product> GetProductByIdAsync(int Id);
        public Task<Product> AddProductAsync(Product product);
        public Task<int> UpdateProductAsync(Product product);
        public Task<int> DeleteProductAsync(int Id);
    }
}
