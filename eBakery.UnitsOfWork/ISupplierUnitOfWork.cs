using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eBakery.UnitOfWork.ViewModels;

namespace eBakery.UnitOfWork
{
    public interface ISupplierUnitOfWork
    {
        Task<List<SupplierDisplayViewModel>> SupplierDisplayList();
        Task<List<SupplierViewModel>> SupplierList();
        Task<SupplierViewModel> SupplierById(int SupplierId);
        Task SaveSupplierData(int SupplierId, string CompanyName, string ContactName, string ContactTitle, string Address, string City, int StateId, string ZipCode, string Phone, string Email, string Notes);
    }
}
