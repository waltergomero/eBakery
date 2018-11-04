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

        public async Task<SupplierModel[]> SupplierList()
        {
            return await _supplierRepository.SupplierList();

        }
        public async Task<SupplierModel> SupplierById(int SupplierId)
        {
            return await _supplierRepository.SupplierById(SupplierId);

        }

        public async Task SaveSupplierData(int SupplierId, string CompanyName, string ContactName, string ContactTitle, string Address, string City, int StateId, string ZipCode, string Phone, string Email, string Notes)
        {
            await _supplierRepository.SaveSupplierData(SupplierId, CompanyName, ContactName, ContactTitle, Address, City, StateId, ZipCode, Phone, Email, Notes);
        }
    }
}
