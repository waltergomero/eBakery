using System.Threading.Tasks;
using eBakery.Contracts.Models;

namespace eBakery.Contracts.Repositories
{
   public interface ISupplierRepository
    {
        Task<SupplierDisplayModel[]> SupplierDisplayList();
        Task<SupplierModel[]> SupplierList();
        Task<SupplierModel> SupplierById(int SupplierId);
        Task SaveSupplierData(int SupplierId, string CompanyName, string ContactName, string ContactTitle, string Address, string City, int StateId, string ZipCode, string Phone, string Email, string Notes);
    }
}
