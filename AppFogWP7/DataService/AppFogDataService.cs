using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Runtime.Serialization;
using AppFogWP7.Utils;
using GalaSoft.MvvmLight;
using AppFogWP7.Model;
using System.Net;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json.Linq;

namespace AppFogWP7.DataService
{
    public class AppFogDataService
    {
        
        public async Task<InfoModel> GetInfo()
        {
            IWebClient client = GetClient();

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

        public async Task<ObservableCollection<AppModel>> GetApps()
        {
            ObservableCollection<AppModel> apps = new ObservableCollection<AppModel>();
            IWebClient client = GetClient();
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

        private IWebClient GetClient()
        {
            IWebClient client;
            bool isUnitTest = AppDomain.CurrentDomain.GetAssemblies().Any(a => a.FullName.StartsWith("Microsoft.VisualStudio.QualityTools.UnitTestFramework"));

            if (isUnitTest)
            {
                client = new MockWebClient();
            }
            else
            {
                client = new MyWebClient {AuthHeader = (App.Current as App).AuthToken};
            }

            return client;
        }
    }
}