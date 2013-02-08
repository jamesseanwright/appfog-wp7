using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFogWP7.DataService.Factories
{
    public interface IWebClientFactory
    {
        IWebClient CreateClient();
    }
}
