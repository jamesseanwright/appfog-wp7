using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFogWP7.Utils;
using AppFogWP7.Model;
using Newtonsoft.Json.Linq;

namespace AppFogWP7.DataService
{
    public class AppFogDataService
    {
        public bool IsUnitTest;

        public AppFogDataService()
        {
            IsUnitTest = AppDomain.CurrentDomain.GetAssemblies().Any(a => a.FullName.StartsWith("Microsoft.VisualStudio.QualityTools.UnitTestFramework"));
        }

        public async Task<InfoModel> GetInfo(string token)
        {
            IWebClient client = GetClient(token);

            string data = await client.DownloadStringTaskAsync(new Uri("https://api.appfog.com/info"));

            InfoModel newModel = new InfoModel();

            JObject infoJson = JObject.Parse(data);
            newModel.User = infoJson["user"].ToString();
            newModel.Plan = infoJson["plan"].ToString();

            foreach (JToken framework in infoJson["frameworks"].Children())
            {
                newModel.Frameworks.Add(framework.First["name"].ToString());
            }

            newModel.Apps = (int) infoJson["usage"]["apps"];
            newModel.MemoryUsed = (int) infoJson["usage"]["memory"];
            newModel.TotalMemory = (int) infoJson["limits"]["memory"];

            return newModel;
        }

        public async Task<List<AppModel>> GetApps(string token)
        {
            List<AppModel> apps = new List<AppModel>();
            
            IWebClient client = GetClient(token);
            
            string data = await client.DownloadStringTaskAsync(new Uri("https://api.appfog.com/apps"));

            JArray appsJson = JArray.Parse(data);
            
            AppModel newModel;

            foreach(JToken app in appsJson)
            {
                newModel = new AppModel
                               {
                                   Name = app["name"].ToString(),
                                   Instances = (int) app["instances"],
                                   Stack = app["staging"]["stack"].ToString(),
                                   Memory = (int) app["resources"]["memory"],
                                   Created = DateUtils.TimeStampToDateTime((double) app["meta"]["created"])
                               };

                foreach (JToken uri in app["uris"])
                {
                    newModel.Uris.Add(uri.ToString());
                }

                apps.Add(newModel);
            }

            return apps;
        }

        public IWebClient GetClient(string token)
        {
            IWebClient client;

            if (IsUnitTest)
            {
                client = new MockWebClient();
            }
            else
            {
                client = new MyWebClient { AuthHeader = token };
            }

            return client;
        }
    }
}