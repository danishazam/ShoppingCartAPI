using ShoppingCartAPI.Data;
using ShoppingCartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCartAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _dbContext;

        public ProductRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            var result = _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteProductAsync(int Id)
        {
            var filteredData = _dbContext.Products.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Products.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(int Id)
        {
            return await _dbContext.Products.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetProductListAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            _dbContext.Products.Update(product);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
