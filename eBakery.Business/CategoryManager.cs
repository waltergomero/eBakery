using System;
using System.Collections.Generic;
using System.Text;
using eBakery.Contracts.Repositories;
using eBakery.Contracts.Services;
using eBakery.Contracts.Models;
using System.Threading.Tasks;

namespace eBakery.Business
{
    public class CategoryManager: ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

        }

        public async Task<CategoryModel[]> CategoryList()
        {
            return await _categoryRepository.CategoryList();

        }

        public async Task<CategoryModel> CategoryById(int CategoryId)
        {
            return await _categoryRepository.CategoryById(CategoryId);

        }

        public async Task SaveCategoryData(int CategoryId, string CategoryName, string Description, int ParentCategoryId, int StatusId)
        {
            await _categoryRepository.SaveCategoryData(CategoryId, CategoryName, Description, ParentCategoryId, StatusId);
        }
    }
}
