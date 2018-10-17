using System.Threading.Tasks;
using eBakery.Contracts.Models;

namespace eBakery.Contracts.Repositories
{
    public interface IProductRepository
    {
        Task<ProductDisplayModel[]> ProductDisplayList();
        Task<ProductModel> ProductById(int ProductId);
    }
}
