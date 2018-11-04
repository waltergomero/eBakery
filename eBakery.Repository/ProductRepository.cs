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
                    _product.SupplierName = dataReader.GetValueOrDefault<string>("CompanyName");
                    _product.QuantityPerUnit = dataReader.GetValueOrDefault<string>("QuantityPerUnit");
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

        public async Task SaveProductData(int ProductId, string ProductName, string ProductCode, int SupplierId, int CategoryId, string QuantityPerUnit, decimal UnitPrice, decimal UnitSalePrice,
                             int UnitsInStock, int UnitsOnOrder, int ReOrderLevel, bool Discontinued, int StatusId, string Notes, string UserEmail)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                if (ProductId > 0)
                {
                    dynamicParameters.Add("@p_intProductId", ProductId);
                }

                dynamicParameters.Add("@p_chrProductName", ProductName);
                dynamicParameters.Add("@p_chrProductCode", ProductCode);
                dynamicParameters.Add("@p_intSupplierId", SupplierId);
                dynamicParameters.Add("@p_intCategoryId", CategoryId);
                dynamicParameters.Add("@p_chrQuantityPerUnit", QuantityPerUnit);
                dynamicParameters.Add("@p_decUnitPrice", UnitPrice);
                dynamicParameters.Add("@p_decUnitSalePrice", UnitSalePrice);
                dynamicParameters.Add("@p_intUnitsInStock", UnitsInStock);
                dynamicParameters.Add("@p_intUnitsOnOrder", UnitsOnOrder);
                dynamicParameters.Add("@p_intReOrderLevel", ReOrderLevel);
                dynamicParameters.Add("@p_boolDiscontinued", Discontinued);
                dynamicParameters.Add("@p_intStatusId", StatusId);
                dynamicParameters.Add("@p_chrNotes", Notes);
                dynamicParameters.Add("@p_chrUserEmail", UserEmail);

                if (ProductId == 0)
                    await sqlConnection.ExecuteAsync("usp_ProductAdd", dynamicParameters, commandType: CommandType.StoredProcedure);
                else
                    await sqlConnection.ExecuteAsync("usp_ProductUpdate", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
