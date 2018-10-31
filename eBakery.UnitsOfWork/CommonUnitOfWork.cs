using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using eBakery.Contracts.Services;
using eBakery.Contracts.Models;
using eBakery.UnitOfWork.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eBakery.UnitOfWork
{
    public class CommonUnitOfWork: ICommonUnitOfWork
    {
        private readonly ICategoryService _categoryService;
        private readonly ICommonService _commonService;
        public CommonUnitOfWork(ICommonService commonService, ICategoryService categoryService)
        {
            _commonService = commonService;
            _categoryService = categoryService;

        }
        public List<SelectListItem> CategoryDropDownList(List<CategoryViewModel> categoryList, string categoryId, string categoryName)
        {
            var selectListSorted = new List<SelectListItem>();
            var selectList = new List<SelectListItem>();
            foreach (var c in categoryList)
                selectList.Add(new SelectListItem()
                {
                    Value = c.CategoryId.ToString(),
                    Text = GetFormattedBreadCrumb(c.CategoryId, categoryList)
                });
            selectListSorted = selectList.OrderBy(c => c.Text).ToList();
            //selectListSorted.Insert(0, new SelectListItem { Text = "[None]", Value = "0" });
            return selectListSorted;
        }

        public string GetFormattedBreadCrumb(int Id, List<CategoryViewModel> categories)
        {
            CategoryViewModel category = categories.Find(x => x.CategoryId == Id);

            string result = string.Empty;
            string separator = ">>";
            //used to prevent circular references
            var alreadyProcessedCategoryIds = new List<int>() { };

            while (category != null &&  //not null
                 !alreadyProcessedCategoryIds.Contains(category.CategoryId)) //prevent circular references
            {
                if (String.IsNullOrEmpty(result))
                {
                    result = category.CategoryName;
                }
                else
                {
                    result = string.Format("{0} {1} {2}", category.CategoryName, separator, result);
                }

                alreadyProcessedCategoryIds.Add(category.CategoryId);

                category = categories.Find(x => x.CategoryId == category.ParentCategoryId);

            }
            return result;
        }
        public List<SelectListItem> StatusDropDownList(List<StatusViewModel> statusList, string statusId, string statusName, int selStatusId)
        {
            var selectList = new SelectList(statusList, statusId, statusName, selStatusId);
            return selectList.ToList();
        }

        public async Task<List<CommonStateListViewModel>> StateList()
        {
            var state = await _commonService.StateList();

            if (state != null)
            {
                var stateItems = state.Select(x => new CommonStateListViewModel
                {
                    StateId = x.StateId,
                    StateName = x.StateName,
                    StateCode = x.StateCode
                }).ToArray();
                return stateItems.ToList();
            }
            return null;
        }

        public List<SelectListItem> StateDropDownList(List<CommonStateListViewModel> stateList, string stateId, string stateName, int selStateId)
        {
            var selectList = new SelectList(stateList, stateId, stateName, selStateId);
            return selectList.ToList();
        }

    }
}
