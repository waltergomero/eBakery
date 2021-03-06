﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eBakery.UnitOfWork.ViewModels;
using eBakery.UnitOfWork;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eBakery.Web.Razor.Pages.app.Category
{
    public class AddEditCategoryModel : PageModel
    {
        private readonly ICategoryUnitOfWork _categoryUnitOfWork;
        private readonly IStatusUnitOfWork _statusUnitOfWork;
        private readonly ICommonUnitOfWork _commonUnitOfWork;

        public AddEditCategoryModel(ICategoryUnitOfWork categoryUnitOfWork, IStatusUnitOfWork statusUnitOfWork, ICommonUnitOfWork commonUnitOfWork)
        {
            _categoryUnitOfWork = categoryUnitOfWork;
            _statusUnitOfWork = statusUnitOfWork;
            _commonUnitOfWork = commonUnitOfWork;
        }

        public string Message { get; private set; } = "";
        public string Title { get; private set; } = "";

        [BindProperty]
        public CategoryViewModel CategoryVM { get; set; }
        public List<StatusViewModel> statusVMList { get; set; }
        public List<SelectListItem> statusIdSelected { get; set; }
        public List<SelectListItem> parentCategoryIdSelected { get; set; }
    
        public List<CategoryViewModel> categoryVMList { get; set; }


        public async Task<IActionResult> OnGetAsync(int Id = 0)
        {
            int selParentCategoryId = 0;

            if (Id > 0)
            {
                Title = "Edit Product";
                CategoryVM = await _categoryUnitOfWork.CategoryById(Id);
                statusVMList = await _statusUnitOfWork.StatusList();

                selParentCategoryId = CategoryVM.ParentCategoryId;

                statusIdSelected = _commonUnitOfWork.StatusDropDownList(statusVMList, "StatusId", "StatusName", CategoryVM.StatusId);

                if (CategoryVM == null)
                {
                    Message = "No records found.";
                }
            }
            else
            {
                Title = "Add Product";

            }
            categoryVMList = await _categoryUnitOfWork.CategoryList();
            parentCategoryIdSelected = _commonUnitOfWork.CategoryDropDownList(categoryVMList, "CategoryId", "CategoryName");

            return Page();
        }

        //public void StatusDropDownList(List<StatusViewModel> statusList, string statusId, string statusName, int selStatusId)
        //{
        //    var selectList = new SelectList(statusList, statusId, statusName, selStatusId);
        //    statusIdSelected = selectList.ToList();
        //}

 

        //Method to save the data back to database
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                    int CategoryId = CategoryVM.CategoryId;
                    string CategoryName = CategoryVM.CategoryName;
                    string Description = CategoryVM.Description;
                    int ParentCategoryId = CategoryVM.ParentCategoryId;
                    int StatusId = CategoryVM.StatusId;

                    await this._categoryUnitOfWork.SaveCategoryData(CategoryId, CategoryName, Description, ParentCategoryId, StatusId);
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