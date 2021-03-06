﻿using System.Collections.Generic;
using System.Text;
using eBakery.Contracts.Repositories;
using eBakery.Contracts.Models;
using eBakery.Infrastructure.BaseClass;
using eBakery.Infrastructure.BaseClass.ApplicationProperties;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace eBakery.Repository
{
    public class CategoryRepository: BaseRepository, ICategoryRepository
    {
        private readonly string connectionString;

        public CategoryRepository(IApplicationProperties applicationProperties) : base(applicationProperties)
        {
            connectionString = applicationProperties.ConnectionString;
        }

        public async Task<CategoryModel[]> CategoryList()
        {
            List<CategoryModel> category = new List<CategoryModel>();
            CategoryModel _category = null;
            var parameters = new SqlParameter[0];
            using (SqlDataReader dataReader = await this.ExecuteReader("usp_CategoryList", parameters))
            {
                while (dataReader.Read())
                {
                    _category = new CategoryModel();
                    _category.CategoryId = dataReader.GetValueOrDefault<int>("CategoryId");
                    _category.CategoryName = dataReader.GetValueOrDefault<string>("CategoryName");
                    _category.Description = dataReader.GetValueOrDefault<string>("Description");
                    _category.ParentCategoryId = dataReader.GetValueOrDefault<int>("ParentCategoryId");
                    _category.Picture = dataReader.GetValueOrDefault<string>("Picture");
                    _category.StatusId = dataReader.GetValueOrDefault<int>("StatusId");
                    category.Add(_category);
                }
            }
            return category.ToArray();
        }

        public async Task<CategoryDisplayModel[]> CategoryDisplayList()
        {
            List<CategoryDisplayModel> category = new List<CategoryDisplayModel>();
            CategoryDisplayModel _category = null;
            var parameters = new SqlParameter[0];
            using (SqlDataReader dataReader = await this.ExecuteReader("usp_CategoryDisplayList", parameters))
            {
                while (dataReader.Read())
                {
                    _category = new CategoryDisplayModel();
                    _category.CategoryId = dataReader.GetValueOrDefault<int>("CategoryId");
                    _category.CategoryName = dataReader.GetValueOrDefault<string>("CategoryName");
                    _category.Description = dataReader.GetValueOrDefault<string>("Description");
                    _category.ParentCategoryName = dataReader.GetValueOrDefault<string>("ParentCategoryName");
                    _category.Picture = dataReader.GetValueOrDefault<string>("Picture");
                    _category.StatusName = dataReader.GetValueOrDefault<string>("StatusName");
                    category.Add(_category);
                }
            }
            return category.ToArray();
        }


        public async Task<CategoryModel> CategoryById(int CategoryId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@p_intCategoryId", CategoryId);
                var query = await sqlConnection.QuerySingleOrDefaultAsync<CategoryModel>("usp_CategoryById", dynamicParameters, commandType: CommandType.StoredProcedure);
                return query;
            }
        }

        public async Task SaveCategoryData(int CategoryId, string CategoryName, string Description, int ParentCategoryId, int StatusId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                if (CategoryId > 0)
                {
                    dynamicParameters.Add("@p_intCategoryId", CategoryId);
                }

                dynamicParameters.Add("@p_chrCategoryName", CategoryName);
                dynamicParameters.Add("@p_chrDescription", Description);
                dynamicParameters.Add("@p_intParentCategoryId", ParentCategoryId);
                dynamicParameters.Add("@p_intStatusId", StatusId);

                if (CategoryId == 0)
                    await sqlConnection.ExecuteAsync("usp_CategoryAdd", dynamicParameters, commandType: CommandType.StoredProcedure);
                else
                    await sqlConnection.ExecuteAsync("usp_CategoryUpdate", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
