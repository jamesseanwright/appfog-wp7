using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace AppFogWP7.DataService
{
    public class MyWebClient : IWebClient
    {
        private WebClient _client = new WebClient();
        private string _authHeader;

        public string AuthHeader
        {
            get { return _authHeader; }
            set 
            {
                _authHeader = value;
                _client.Headers[HttpRequestHeader.Authorization] = _authHeader;
            }
        }

        public async Task<string> DownloadStringTaskAsync(Uri uri)
        {
            return await _client.DownloadStringTaskAsync(uri);
        }
    }
}
