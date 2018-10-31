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
    public class SupplierRepository: BaseRepository, ISupplierRepository
    {
        private readonly string connectionString;

        public SupplierRepository(IApplicationProperties applicationProperties) : base(applicationProperties)
        {
            connectionString = applicationProperties.ConnectionString;
        }
        public async Task<SupplierDisplayModel[]> SupplierDisplayList()
        {
            List<SupplierDisplayModel> supplier = new List<SupplierDisplayModel>();
            SupplierDisplayModel _supplier = null;
            var parameters = new SqlParameter[0];
            using (SqlDataReader dataReader = await this.ExecuteReader("usp_SupplierDisplayList", parameters))
            {
                while (dataReader.Read())
                {
                    _supplier = new SupplierDisplayModel();
                    _supplier.SupplierId = dataReader.GetValueOrDefault<int>("SupplierId");
                    _supplier.CompanyName = dataReader.GetValueOrDefault<string>("CompanyName");
                    _supplier.ContactName = dataReader.GetValueOrDefault<string>("ContactName");
                    _supplier.ContactTitle = dataReader.GetValueOrDefault<string>("ContactTitle");
                    _supplier.Address = dataReader.GetValueOrDefault<string>("Address");
                    _supplier.City = dataReader.GetValueOrDefault<string>("City");
                    _supplier.StateName = dataReader.GetValueOrDefault<string>("StateName");
                    _supplier.ZipCode = dataReader.GetValueOrDefault<string>("ZipCode");
                    _supplier.Email = dataReader.GetValueOrDefault<string>("Email");
                    _supplier.Phone = dataReader.GetValueOrDefault<string>("Phone");
                    supplier.Add(_supplier);
                }
            }
            return supplier.ToArray();
        }

        public async Task<SupplierModel> SupplierById(int SupplierId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@p_intSupplierId", SupplierId);
                var query = await sqlConnection.QuerySingleOrDefaultAsync<SupplierModel>("usp_SupplierById", dynamicParameters, commandType: CommandType.StoredProcedure);
                return query;
            }
        }
    }
}
