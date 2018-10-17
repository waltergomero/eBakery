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
    }
}
