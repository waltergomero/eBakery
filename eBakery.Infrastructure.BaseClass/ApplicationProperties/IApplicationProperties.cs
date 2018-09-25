using System;
using System.Collections.Generic;
using System.Text;

namespace eBakery.Infrastructure.BaseClass.ApplicationProperties
{
    public interface IApplicationProperties
    {
        string ConnectionString { get; }
        string Environment { get; }
    }

}

