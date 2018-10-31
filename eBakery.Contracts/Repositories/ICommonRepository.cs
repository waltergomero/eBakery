using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eBakery.Contracts.Models;

namespace eBakery.Contracts.Repositories
{
    public interface ICommonRepository
    {
        Task<CommonModelStateList[]> StateList();
    }
}
