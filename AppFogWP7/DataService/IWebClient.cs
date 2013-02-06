using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppFogWP7.DataService
{
    interface IWebClient
    {
        string AuthHeader { get; set; }
        Task<string> DownloadStringTaskAsync(Uri uri);
    }
}
