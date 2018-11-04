using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eBakery.UnitOfWork.ViewModels;
using eBakery.UnitOfWork;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eBakery.Web.Pages.app.Product
{
    public class AddEditProductModel : PageModel
    {
        private readonly IProductUnitOfWork _productUnitOfWork;
        private readonly ICategoryUnitOfWork _categoryUnitOfWork;
        private readonly IStatusUnitOfWork _statusUnitOfWork;
        private readonly ICommonUnitOfWork _commonUnitOfWork;
        private readonly ISupplierUnitOfWork _supplierUnitOfWork;

        public AddEditProductModel(IProductUnitOfWork productUnitOfWork, ICategoryUnitOfWork categoryUnitOfWork, IStatusUnitOfWork statusUnitOfWork, ICommonUnitOfWork commonUnitOfWork, ISupplierUnitOfWork supplierUnitOfWork)
        {
            _productUnitOfWork = productUnitOfWork;
            _categoryUnitOfWork = categoryUnitOfWork;
            _statusUnitOfWork = statusUnitOfWork;
            _commonUnitOfWork = commonUnitOfWork;
            _supplierUnitOfWork = supplierUnitOfWork;
        }

        [BindProperty]
        public ProductViewModel ProductVM { get; set; }
        public List<StatusViewModel> statusListVM { get; set; }
        public List<SelectListItem> StatusList { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
        public List<CategoryViewModel> categoryListVM { get; set; }
        public List<SupplierViewModel> supplierListVM { get; set; }
        public List<SelectListItem> SupplierList { get; set; }

        public string Message { get; private set; } = "";
        public string Title { get; private set; } = "";

        public async Task<IActionResult> OnGetAsync(int Id = 0)
        {
            categoryListVM = await _categoryUnitOfWork.CategoryList();
            CategoryList = _commonUnitOfWork.CategoryDropDownList(categoryListVM, "CategoryId", "CategoryName");

            supplierListVM = await _supplierUnitOfWork.SupplierList();
            

            if (Id > 0)
            {
                Title = "Edit";
                ProductVM = await _productUnitOfWork.ProductById(Id);
                statusListVM = await _statusUnitOfWork.StatusList();

                SupplierList = _commonUnitOfWork.SupplierDropDownList(supplierListVM, "SupplierId", "CompanyName", ProductVM.SupplierId);
                StatusList = _commonUnitOfWork.StatusDropDownList(statusListVM, "StatusId", "StatusName", ProductVM.StatusId);


                if (ProductVM == null)
                {
                    Message = "No records found.";
                }
            }
            else
            {
                Title = "Add";
                SupplierList = _commonUnitOfWork.SupplierDropDownList(supplierListVM, "SupplierId", "CompanyName", 0);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string UserEmail = User.Identity.Name;
            try
            {
                int ProductId = ProductVM.ProductId;
                string ProductName = ProductVM.ProductName;
                string ProductCode = ProductVM.ProductCode;
                int SupplierId = ProductVM.SupplierId;
                int CategoryId = ProductVM.CategoryId;
                string QuantityPerUnit = ProductVM.QuantityPerUnit;
                decimal UnitPrice = ProductVM.UnitPrice;
                decimal UnitSalePrice = ProductVM.UnitSalePrice;
                int UnitsInStock = ProductVM.UnitsInStock;
                int UnitsOnOrder = ProductVM.UnitsOnOrder;
                int ReOrderLevel = ProductVM.ReorderLevel;
                bool Discontinued = ProductVM.Discontinued;
                int StatusId = ProductVM.StatusId;
                string  Notes = ProductVM.Notes;

                await this._productUnitOfWork.SaveProductData(ProductId, ProductName, ProductCode, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, UnitSalePrice,
                                                              UnitsInStock, UnitsOnOrder, ReOrderLevel, Discontinued, StatusId, Notes, UserEmail);
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