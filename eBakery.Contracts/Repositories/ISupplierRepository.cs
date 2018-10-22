using System.Threading.Tasks;
using eBakery.Contracts.Models;

namespace eBakery.Contracts.Repositories
{
   public interface ISupplierRepository
    {
        Task<SupplierDisplayModel[]> SupplierDisplayList();
        Task<SupplierModel> SupplierById(int SupplierId);
    }
}
