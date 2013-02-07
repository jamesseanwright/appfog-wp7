using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace AppFogWP7.DataService
{
    public partial class MockWebClient : IWebClient
    {
        public async Task<string> DownloadStringTaskAsync(Uri uri)
        {
            if (uri.AbsolutePath.Contains("info"))
            {
                return "{ \"user\": \"test_user\", \"plan\": \"test_plan\"," +
                       "\"frameworks\": { \"framework\": { \"name\": \"Test Framework\" } }, \"usage\": " +
                       "{ \"apps\": 1, \"memory\": 256 }, \"limits\": { \"memory\": 2048 } }";
            }
            
            return "[{ \"name\": \"test_app\", \"instances\": 1, " +
                    "\"staging\": { \"stack\": \"test_stack\"}, \"resources\": " +
                       "{ \"memory\": 256 }, \"uris\": [\"jamesswright.eu01.aws.af.cm\"], " +
                       "\"meta\": { \"created\": \"1359854226\" } }]";
        }

        public string AuthHeader { get; set; }
    }
}