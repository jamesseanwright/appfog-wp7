using System;
using System.Threading;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Runtime.Serialization;
using GalaSoft.MvvmLight;
using AppFogWP7.Model;
using System.Net;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json.Linq;

namespace AppFogWP7.DataService
{
    public class AppFogDataService
    {
        public async Task<InfoModel> CallAPI(string token)
        {
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.Authorization] = token;

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
    }
}