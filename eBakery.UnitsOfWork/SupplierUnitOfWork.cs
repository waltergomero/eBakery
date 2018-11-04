using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using eBakery.Contracts.Services;
using eBakery.Contracts.Models;
using eBakery.UnitOfWork.ViewModels;
using System.Threading.Tasks;

namespace eBakery.UnitOfWork
{
    public class SupplierUnitOfWork: ISupplierUnitOfWork
    {
        private readonly ISupplierService _supplierService;

        public SupplierUnitOfWork(ISupplierService supplierService)
        {
            _supplierService = supplierService;

        }
        public async Task<List<SupplierViewModel>> SupplierList()
        {
            var supplier = await _supplierService.SupplierList();

            if (supplier != null)
            {
                var supplierItems = supplier.Select(x => new SupplierViewModel
                {
                    SupplierId = x.SupplierId,
                    CompanyName = x.CompanyName
                }).ToArray();
                return supplierItems.ToList();
            }
            return null;
        }


        public async Task<List<SupplierDisplayViewModel>> SupplierDisplayList()
        {
            var supplier = await _supplierService.SupplierDisplayList();

            if (supplier != null)
            {
                var supplierItems = supplier.Select(x => new SupplierDisplayViewModel
                {
                    SupplierId = x.SupplierId,
                    CompanyName = x.CompanyName,
                    ContactName = x.ContactName,
                    ContactTitle = x.ContactTitle,
                    Address = x.Address,
                    City = x.City,
                    StateName = x.StateName,
                    Phone = x.Phone,
                    Email = x.Email
                }).ToArray();
                return supplierItems.ToList();
            }
            return null;
        }

        public async Task<SupplierViewModel> SupplierById(int SupplierId)
        {
            var x = await _supplierService.SupplierById(SupplierId);

            SupplierViewModel sVM = new SupplierViewModel();
            sVM.SupplierId = x.SupplierId;
            sVM.CompanyName = x.CompanyName;
            sVM.ContactName = x.ContactName;
            sVM.ContactTitle = x.ContactTitle;
            sVM.Address = x.Address;
            sVM.City = x.City;
            sVM.ZipCode = x.ZipCode;
            sVM.StateId = x.StateId;
            sVM.Phone = x.Phone;
            sVM.Email = x.Email;
            sVM.Notes = x.Notes;

            return sVM;
        }

        public async Task SaveSupplierData(int SupplierId, string CompanyName, string ContactName, string ContactTitle, string Address, string City, int StateId, string ZipCode, string Phone, string Email, string Notes)
        {
            await _supplierService.SaveSupplierData(SupplierId, CompanyName, ContactName, ContactTitle, Address, City, StateId, ZipCode, Phone, Email, Notes);
        }
    }
}
