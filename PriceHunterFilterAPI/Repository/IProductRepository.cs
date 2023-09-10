using PriceHunterFilterAPI.DataAccess.Model;

namespace PriceHunterFilterAPI.Repository
{
    public interface IProductRepository
    {
        void Upsert(Product product);
    }
}