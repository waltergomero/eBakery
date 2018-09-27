using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eBakery.Contracts.Models;

namespace eBakery.Contracts.Services
{
    public interface ICategoryService
    {
        Task<CategoryModel[]> CategoryList();
        Task<CategoryDisplayModel[]> CategoryDisplayList();
        Task<CategoryModel> CategoryById(int CategoryId);
        Task SaveCategoryData(int CategoryId, string CategoryName, string Description, int ParentCategoryId, int StatusId);

    }
}
