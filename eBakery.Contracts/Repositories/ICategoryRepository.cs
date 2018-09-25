using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eBakery.Contracts.Models;
namespace eBakery.Contracts.Repositories
{
    public interface ICategoryRepository
    {
        Task<CategoryModel[]> CategoryList();
        Task<CategoryModel> CategoryById(int CategoryId);
        Task SaveCategoryData(int CategoryId, string CategoryName, string Description, int ParentCategoryId, int StatusId);

    }
}
