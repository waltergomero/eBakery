using System;
using System.Collections.Generic;
using System.Text;
using eBakery.Contracts.Repositories;
using eBakery.Contracts.Services;
using eBakery.Contracts.Models;
using System.Threading.Tasks;

namespace eBakery.Business
{
    public class CommonManager: ICommonService
    {
        private readonly ICommonRepository _commonRepository;

        public CommonManager(ICommonRepository commonRepository)
        {
            _commonRepository = commonRepository;

        }

        public async Task<CommonModelStateList[]> StateList()
        {
            return await _commonRepository.StateList();

        }
    }
}
