using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eBakery.UnitOfWork.ViewModels;

namespace eBakery.UnitOfWork
{
    public interface IStatusUnitOfWork
    {
        Task<List<StatusViewModel>> StatusList();
        Task<List<StatusViewModel>> StatusListByType(int TypeId);
        Task<StatusViewModel[]> StatusListArray();
        Task<StatusViewModel> StatusById(int StatusId);
        Task SaveStatusData(string StatusName, int StatusId, int StatusType);
    }
}
