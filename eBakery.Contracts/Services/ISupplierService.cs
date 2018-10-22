using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eBakery.Contracts.Models;

namespace eBakery.Contracts.Services
{
    public interface ISupplierService
    {
        Task<SupplierDisplayModel[]> SupplierDisplayList();
        Task<SupplierModel> SupplierById(int SupplierId);
    }
}
