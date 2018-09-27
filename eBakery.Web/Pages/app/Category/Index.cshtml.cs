using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eBakery.UnitOfWork;
using eBakery.UnitOfWork.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace eBakery.Web.Razor.Pages.app.Category
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryUnitOfWork _categoryUnitOfWork;

        public IndexModel(ICategoryUnitOfWork categoryUnitOfWork)
        {
            _categoryUnitOfWork = categoryUnitOfWork;
        }

        public string Message { get; private set; } = "";


        public List<CategoryDisplayViewModel> category { get; set; } = new List<CategoryDisplayViewModel>();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                category = await _categoryUnitOfWork.CategoryDisplayList();
            }
            catch(Exception ex)
            {
                Message = ex.Message;
            }

            return Page();
        }
    }
}