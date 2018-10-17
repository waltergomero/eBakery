using System.Threading.Tasks;
using eBakery.Contracts.Models;

namespace eBakery.Contracts.Services
{
    public interface IProductService
    {
        Task<ProductDisplayModel[]> ProductDisplayList();
        Task<ProductModel> ProductById(int ProductId);
    }
}
