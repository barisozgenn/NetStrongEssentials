using RedisExampleBaris.API.Models;

namespace RedisExampleBaris.API.Repositories
{
    public interface IProductRepository
    {

        Task<List<Product>> GetAsync();

        Task<Product> GetByIdAsync(int id);

        Task<Product> CreateAsync(Product product);
    }
}
