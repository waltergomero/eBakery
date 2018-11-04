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

        public async Task<SupplierModel[]> SupplierList()
        {
            List<SupplierModel> supplier = new List<SupplierModel>();
            SupplierModel _supplier = null;
            var parameters = new SqlParameter[0];
            using (SqlDataReader dataReader = await this.ExecuteReader("usp_SupplierList", parameters))
            {
                while (dataReader.Read())
                {
                    _supplier = new SupplierModel();
                    _supplier.SupplierId = dataReader.GetValueOrDefault<int>("SupplierId");
                    _supplier.CompanyName = dataReader.GetValueOrDefault<string>("CompanyName");
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

        public async Task SaveSupplierData(int SupplierId, string CompanyName, string ContactName, string ContactTitle, string Address, string City, int StateId, string ZipCode, string Phone, string Email, string Notes)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                if (SupplierId > 0)
                {
                    dynamicParameters.Add("@p_intSupplierId", SupplierId);
                }

                dynamicParameters.Add("@p_chrCompanyName", CompanyName);
                dynamicParameters.Add("@p_chrContactName", ContactName);
                dynamicParameters.Add("@p_chrContactTitle", ContactTitle);
                dynamicParameters.Add("@p_chrAddress", Address);
                dynamicParameters.Add("@p_chrCity", City);
                dynamicParameters.Add("@p_intStateId", StateId);
                dynamicParameters.Add("@p_chrZipCode", ZipCode);
                dynamicParameters.Add("@p_chrPhone", Phone);
                dynamicParameters.Add("@p_chrEmail", Email);
                dynamicParameters.Add("@p_chrNotes", Notes);


                if (SupplierId == 0)
                    await sqlConnection.ExecuteAsync("usp_SupplierAdd", dynamicParameters, commandType: CommandType.StoredProcedure);
                else
                    await sqlConnection.ExecuteAsync("usp_SupplierUpdate", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
