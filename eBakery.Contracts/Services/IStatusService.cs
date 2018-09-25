using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eBakery.Contracts.Models;

namespace eBakery.Contracts.Services
{
   public interface IStatusService
    {
        Task<StatusModel[]> StatusList();
        Task<StatusModel[]> StatusListByType(int TypeId);
        Task<StatusModel> StatusById(int StatusId);
        Task SaveStatusData(string StatusName, int StatusId, int StatusType);
    }
}
