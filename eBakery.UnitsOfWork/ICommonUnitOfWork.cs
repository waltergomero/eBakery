using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using eBakery.UnitOfWork.ViewModels;
using System.Threading.Tasks;

namespace eBakery.UnitOfWork
{
    public interface ICommonUnitOfWork
    {
        List<SelectListItem> CategoryDropDownList(List<CategoryViewModel> categoryList, string categoryId, string categoryName);
        List<SelectListItem> StatusDropDownList(List<StatusViewModel> statusList, string statusId, string statusName, int selStatusId);
        Task<List<CommonStateListViewModel>> StateList();
        List<SelectListItem> StateDropDownList(List<CommonStateListViewModel> stateList, string stateId, string stateName, int selStateId);
        List<SelectListItem> SupplierDropDownList(List<SupplierViewModel> supplierList, string supplierId, string companyName, int selSupplierId);
    }
}
