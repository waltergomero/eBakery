﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using eBakery.Contracts.Services;
using eBakery.Contracts.Models;
using eBakery.UnitOfWork.ViewModels;
using System.Threading.Tasks;

namespace eBakery.UnitOfWork
{
    public class CategoryUnitOfWork: ICategoryUnitOfWork
    {
        private readonly ICategoryService _categoryService;

        public CategoryUnitOfWork(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        public async Task<List<CategoryViewModel>> CategoryList()
        {
            var category = await _categoryService.CategoryList();

            if (category != null)
            {
                var categoryItems = category.Select(x => new CategoryViewModel
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,
                    Description = x.Description,
                    Picture = x.Picture,
                    ParentCategoryId = x.ParentCategoryId,
                    StatusId = x.StatusId
                }).ToArray();
                return categoryItems.ToList();
            }
            return null;
        }

        public async Task<List<CategoryDisplayViewModel>> CategoryDisplayList()
        {
            var category = await _categoryService.CategoryDisplayList();

            if (category != null)
            {
                var categoryItems = category.Select(x => new CategoryDisplayViewModel
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,
                    Description = x.Description,
                    Picture = x.Picture,
                    ParentCategoryName = x.ParentCategoryName,
                    StatusName = x.StatusName
                }).ToArray();
                return categoryItems.ToList();
            }
            return null;
        }


        public async Task<CategoryViewModel[]> CategoryListArray()
        {
            var category = await _categoryService.CategoryList();

            if (category != null)
            {
                var categoryItems = category.Select(x => new CategoryViewModel
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,
                    Description = x.Description,
                    Picture = x.Picture,
                    ParentCategoryId = x.ParentCategoryId,
                    StatusId = x.StatusId
                }).ToArray();
                return categoryItems.ToArray();
            }
            return null;
        }

        public async Task<CategoryViewModel> CategoryById(int CategoryId)
        {
            var c = await _categoryService.CategoryById(CategoryId);

            CategoryViewModel cVM = new CategoryViewModel();
            cVM.CategoryId = c.CategoryId;
            cVM.CategoryName = c.CategoryName;
            cVM.Description = c.Description;
            cVM.ParentCategoryId = c.ParentCategoryId;
            cVM.Picture = c.Picture;
            cVM.StatusId = c.StatusId;

            return cVM;
        }

        public async Task SaveCategoryData(int CategoryId, string CategoryName, string Description, int ParentCategoryId, int StatusId)
        {
            await _categoryService.SaveCategoryData(CategoryId, CategoryName, Description, ParentCategoryId, StatusId);
        }

    }
}
