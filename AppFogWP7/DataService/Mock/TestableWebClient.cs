using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace AppFogWP7.DataService.Mock
{
    partial class TestableWebClient : IDataService
    {
        public async Task<string> DownloadStringTaskAsync(Uri uri)
        {
            return "{ \"user\": \"test_user\", \"plan\": \"test_plan\", " +
                   "\"frameworks\": { \"framework\": { \"name\": \"Test Framework\" } }, \"usage\": " +
                   "{ \"apps\": 1, \"memory\": 256 }, \"limits\": { \"memory\": 2048 } }";
        }

        public string AuthHeader { get; set; }
    }
}