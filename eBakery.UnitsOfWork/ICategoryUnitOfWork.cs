using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eBakery.UnitOfWork.ViewModels;

namespace eBakery.UnitOfWork
{
   public interface ICategoryUnitOfWork
    {
        Task<List<CategoryViewModel>> CategoryList();
        Task<List<CategoryDisplayViewModel>> CategoryDisplayList();
        Task<CategoryViewModel[]> CategoryListArray();
        Task<CategoryViewModel> CategoryById(int StatusId);
        Task SaveCategoryData(int CategoryId, string CategoryName, string Description, int ParentCategoryId, int StatusId);
    }
}
