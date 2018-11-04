using System.Threading.Tasks;
using eBakery.Contracts.Models;

namespace eBakery.Contracts.Services
{
    public interface IProductService
    {
        Task<ProductDisplayModel[]> ProductDisplayList();
        Task<ProductModel> ProductById(int ProductId);
        Task SaveProductData(int ProductId, string ProductName, string ProductCode, int SupplierId, int CategoryId, string QuantityPerUnit, decimal UnitPrice, decimal UnitSalePrice,
                             int UnitsInStock, int UnitsOnOrder, int ReOrderLevel, bool Discontinued, int StatusId, string Notes, string UserEmail);
    }
}
