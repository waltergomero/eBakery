using eBakery.Contracts.Repositories;
using eBakery.Contracts.Services;
using eBakery.Contracts.Models;
using System.Threading.Tasks;

namespace eBakery.Business
{
   public class SupplierManager: ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierManager(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;

        }
        public async Task<SupplierDisplayModel[]> SupplierDisplayList()
        {
            return await _supplierRepository.SupplierDisplayList();
        }

        public async Task<SupplierModel> SupplierById(int SupplierId)
        {
            return await _supplierRepository.SupplierById(SupplierId);

        }
    }
}
