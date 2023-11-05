using PriceHunterFilterAPI.DataAccess.Model;

namespace PriceHunterFilterAPI.Repository
{
    public interface IProductRepository
    {
        Task UpdatePrice(string id, decimal price);
        Task Upsert(Product product);
    }
}