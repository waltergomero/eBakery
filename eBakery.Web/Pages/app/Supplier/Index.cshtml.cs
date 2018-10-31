using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eBakery.UnitOfWork;
using eBakery.UnitOfWork.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace eBakery.Web.Pages.app.Supplier
{
    public class IndexModel : PageModel
    {
        private readonly ISupplierUnitOfWork _supplierUnitOfWork;

        public IndexModel(ISupplierUnitOfWork supplierUnitOfWork)
        {
            _supplierUnitOfWork = supplierUnitOfWork;
        }


        public string Message { get; private set; } = "";

        public List<SupplierDisplayViewModel> supplierVM { get; set; } = new List<SupplierDisplayViewModel>();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                supplierVM = await _supplierUnitOfWork.SupplierDisplayList();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }

            return Page();
        }
    }
}