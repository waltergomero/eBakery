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
    public class CommonRepository: BaseRepository, ICommonRepository
    {
        private readonly string connectionString;

        public CommonRepository(IApplicationProperties applicationProperties) : base(applicationProperties)
        {
            connectionString = applicationProperties.ConnectionString;
        }

        public async Task<CommonModelStateList[]> StateList()
        {
            List<CommonModelStateList> state = new List<CommonModelStateList>();
            CommonModelStateList _state = null;
            var parameters = new SqlParameter[0];
            using (SqlDataReader dataReader = await this.ExecuteReader("usp_StateList", parameters))
            {
                while (dataReader.Read())
                {
                    _state = new CommonModelStateList();
                    _state.StateId = dataReader.GetValueOrDefault<int>("StateId");
                    _state.StateCode = dataReader.GetValueOrDefault<string>("StateCode");
                    _state.StateName = dataReader.GetValueOrDefault<string>("StateName");
                    state.Add(_state);
                }
            }
            return state.ToArray();
        }

    }
}
