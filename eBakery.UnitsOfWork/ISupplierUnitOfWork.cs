using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eBakery.UnitOfWork.ViewModels;

namespace eBakery.UnitOfWork
{
    public interface ISupplierUnitOfWork
    {
        Task<List<SupplierDisplayViewModel>> SupplierDisplayList();
        Task<SupplierViewModel> SupplierById(int SupplierId);
    }
}
