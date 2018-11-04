using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eBakery.UnitOfWork.ViewModels;
using eBakery.UnitOfWork;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eBakery.Web.Pages.app.Supplier
{
    public class AddEditSupplierModel : PageModel
    {
        private readonly ISupplierUnitOfWork _supplierUnitOfWork;
        private readonly IStatusUnitOfWork _statusUnitOfWork;
        private readonly ICommonUnitOfWork _commonUnitOfWork;

        public AddEditSupplierModel(ISupplierUnitOfWork supplierUnitOfWork, IStatusUnitOfWork statusUnitOfWork, ICommonUnitOfWork commonUnitOfWork)
        {
            _supplierUnitOfWork = supplierUnitOfWork;
            _statusUnitOfWork = statusUnitOfWork;
            _commonUnitOfWork = commonUnitOfWork;
        }

        [BindProperty]
        public SupplierViewModel SupplierVM { get; set; }
        public string Message { get; private set; } = "";
        public string Title { get; private set; } = "";

        public List<CommonStateListViewModel> stateVMList { get; set; }
        public List<SelectListItem> stateIdSelected { get; set; }

        public async Task<IActionResult> OnGetAsync(int Id = 0)
        {
            stateVMList = await _commonUnitOfWork.StateList();
            
            if (Id > 0)
            {
                Title = "Edit";
                SupplierVM = await _supplierUnitOfWork.SupplierById(Id);
                stateIdSelected = _commonUnitOfWork.StateDropDownList(stateVMList, "StateId", "StateName", SupplierVM.StateId);

                if (SupplierVM == null)
                {
                    Message = "No records found.";
                }
            }
            else
            {
                Title = "Add";
                stateIdSelected = _commonUnitOfWork.StateDropDownList(stateVMList, "StateId", "StateName", 0);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                int SupplierId = SupplierVM.SupplierId;
                string CompanyName = SupplierVM.CompanyName;
                string ContactName = SupplierVM.ContactName;
                string ContactTitle = SupplierVM.ContactTitle;
                string Address = SupplierVM.Address;
                string City = SupplierVM.City;
                int StateId = SupplierVM.StateId;
                string ZipCode = SupplierVM.ZipCode;
                string Phone = SupplierVM.Phone;
                string Email = SupplierVM.Email;
                string Notes = SupplierVM.Notes;

                await this._supplierUnitOfWork.SaveSupplierData(SupplierId, CompanyName, ContactName, ContactTitle, Address, City, StateId, ZipCode, Phone, Email, Notes);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return Page();
            }
        }

    }
}