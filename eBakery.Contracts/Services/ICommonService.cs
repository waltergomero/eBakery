using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eBakery.Contracts.Models;

namespace eBakery.Contracts.Services
{
   public interface ICommonService
    {
        Task<CommonModelStateList[]> StateList();
    }
}
