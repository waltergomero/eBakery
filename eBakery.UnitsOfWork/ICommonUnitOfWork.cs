using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using eBakery.UnitOfWork.ViewModels;

namespace eBakery.UnitOfWork
{
    public interface ICommonUnitOfWork
    {
        List<SelectListItem> CategoryDropDownList(List<CategoryViewModel> categoryList, string categoryId, string categoryName);
        List<SelectListItem> StatusDropDownList(List<StatusViewModel> statusList, string statusId, string statusName, int selStatusId);

    }
}
