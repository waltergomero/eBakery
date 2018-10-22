using System.Collections.Generic;
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
    public class ProductRepository: BaseRepository, IProductRepository
    {
        private readonly string connectionString;

        public ProductRepository(IApplicationProperties applicationProperties) : base(applicationProperties)
        {
            connectionString = applicationProperties.ConnectionString;
        }
        public async Task<ProductDisplayModel[]> ProductDisplayList()
        {
            List<ProductDisplayModel> product = new List<ProductDisplayModel>();
           ProductDisplayModel _product = null;
            var parameters = new SqlParameter[0];
            using (SqlDataReader dataReader = await this.ExecuteReader("usp_ProductDisplayList", parameters))
            {
                while (dataReader.Read())
                {
                    _product = new ProductDisplayModel();
                    _product.ProductId = dataReader.GetValueOrDefault<int>("ProductId");
                    _product.ProductName = dataReader.GetValueOrDefault<string>("ProductName");
                    _product.ProductCode = dataReader.GetValueOrDefault<string>("ProductCode");
                    _product.CategoryName = dataReader.GetValueOrDefault<string>("CategoryName");
                    _product.SupplierName = dataReader.GetValueOrDefault<string>("SupplierName");
                    _product.QuantityPerUnit = dataReader.GetValueOrDefault<int>("QuantityPerUnit");
                    _product.UnitPrice = dataReader.GetValueOrDefault<decimal>("UnitPrice");
                    _product.UnitSalePrice = dataReader.GetValueOrDefault<decimal>("UnitSalePrice");
                    _product.UnitsInStock = dataReader.GetValueOrDefault<int>("UnitsInStock");
                    _product.UnitsOnOrder = dataReader.GetValueOrDefault<int>("UnitsOnOrder");
                    _product.ReorderLevel = dataReader.GetValueOrDefault<int>("ReorderLevel");
                    _product.Discontinued = dataReader.GetValueOrDefault<bool>("Discontinued");
                    _product.StatusName = dataReader.GetValueOrDefault<string>("StatusName");
                    product.Add(_product);
                }
            }
            return product.ToArray();
        }

        public async Task<ProductModel> ProductById(int ProductId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@p_intProductId", ProductId);
                var query = await sqlConnection.QuerySingleOrDefaultAsync<ProductModel>("usp_ProductById", dynamicParameters, commandType: CommandType.StoredProcedure);
                return query;
            }
        }

    }
}
