using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eBakery.UnitOfWork.ViewModels;

namespace eBakery.UnitOfWork
{
   public interface IProductUnitOfWork
    {
        Task<List<ProductDisplayViewModel>> ProductDisplayList();
        Task<ProductViewModel> ProductById(int ProductId);
        Task SaveProductData(int ProductId, string ProductName, string ProductCode, int SupplierId, int CategoryId, string QuantityPerUnit, decimal UnitPrice, decimal UnitSalePrice,
                             int UnitsInStock, int UnitsOnOrder, int ReOrderLevel, bool Discontinued, int StatusId, string Notes, string UserEmail);
    }
}
