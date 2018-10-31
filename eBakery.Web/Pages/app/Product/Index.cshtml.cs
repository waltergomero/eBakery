using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eBakery.UnitOfWork;
using eBakery.UnitOfWork.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace eBakery.Web.Pages.app.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductUnitOfWork _productUnitOfWork;

        public IndexModel(IProductUnitOfWork productUnitOfWork)
        {
            _productUnitOfWork = productUnitOfWork;
        }


        public string Message { get; private set; } = "";

        public List<ProductDisplayViewModel> productVM { get; set; } = new List<ProductDisplayViewModel>();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                productVM = await _productUnitOfWork.ProductDisplayList();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }

            return Page();
        }
    }
}