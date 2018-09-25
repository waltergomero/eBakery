using System;
using System.Collections.Generic;
using System.Text;
using eBakery.Contracts.Repositories;
using eBakery.Contracts.Services;
using eBakery.Contracts.Models;
using System.Threading.Tasks;

namespace eBakery.Business
{
    public class StatusManager: IStatusService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusManager(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;

        }

        public async Task<StatusModel[]> StatusList()
        {
            return await _statusRepository.StatusList();

        }

        public async Task<StatusModel[]> StatusListByType(int TypeId)
        {
            return await _statusRepository.StatusListByType(TypeId);

        }
        public async Task<StatusModel> StatusById(int StatusId)
        {
            return await _statusRepository.StatusById(StatusId);

        }

        public async Task SaveStatusData(string StatusName, int StatusId, int StatusType)
        {
            await _statusRepository.SaveStatusData(StatusName, StatusId, StatusType);
        }
    }
}
