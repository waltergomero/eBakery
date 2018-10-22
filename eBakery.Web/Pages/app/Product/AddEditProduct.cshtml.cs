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

        public AddEditProductModel(IProductUnitOfWork productUnitOfWork, ICategoryUnitOfWork categoryUnitOfWork, IStatusUnitOfWork statusUnitOfWork, ICommonUnitOfWork commonUnitOfWork)
        {
            _productUnitOfWork = productUnitOfWork;
            _categoryUnitOfWork = categoryUnitOfWork;
            _statusUnitOfWork = statusUnitOfWork;
            _commonUnitOfWork = commonUnitOfWork;
        }

        [BindProperty]
        public ProductViewModel ProductVM { get; set; }
        public List<StatusViewModel> statusListVM { get; set; }
        public List<SelectListItem> StatusList { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
        public List<CategoryViewModel> categoryListVM { get; set; }

        public string Message { get; private set; } = "";
        public string Title { get; private set; } = "";

        public async Task<IActionResult> OnGetAsync(int Id = 0)
        {
            categoryListVM = await _categoryUnitOfWork.CategoryList();
            CategoryList = _commonUnitOfWork.CategoryDropDownList(categoryListVM, "CategoryId", "CategoryName");

            if (Id > 0)
            {
                Title = "Edit";
                ProductVM = await _productUnitOfWork.ProductById(Id);
                statusListVM = await _statusUnitOfWork.StatusList();

                StatusList = _commonUnitOfWork.StatusDropDownList(statusListVM, "StatusId", "StatusName", ProductVM.StatusId);


                if (ProductVM == null)
                {
                    Message = "No records found.";
                }
            }
            else
            {
                Title = "Add";

            }

            return Page();
        }


    }
}