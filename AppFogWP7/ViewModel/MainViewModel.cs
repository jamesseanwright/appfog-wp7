using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.Runtime.Serialization;
using GalaSoft.MvvmLight;
using AppFogWP7.Model;
using System.Net;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace AppFogWP7.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            _infoModel = new InfoModel();
            _loading = false;
            _loaded = false;
            _getInfoCommand = new RelayCommand<string>(GetInfo);
        }

        #region properties

        public InfoModel InfoModel
        {
            get { return _infoModel; }
            set
            {
                _infoModel = value;
                RaisePropertyChanged("InfoModel");
            }
        }

        public RelayCommand<string> GetInfoCommand
        {
            get { return _getInfoCommand; }
        }

        public bool Loading
        {
            get { return _loading; }
            set
            {
                _loading = value;
                RaisePropertyChanged("Loading");
            }
        }

        public bool Loaded
        {
            get { return _loaded; }
            set
            {
                _loaded = value;
                RaisePropertyChanged("Loaded");
            }
        }

        #endregion

        #region methods
        public void GetInfo(string token)
        {
            Loading = true;
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.Authorization] = token;
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(GetInfoDownloadStringCompleted);
            client.DownloadStringAsync(new Uri("https://api.appfog.com/info"));
        }
        public void GetInfoDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs args)
        {
            InfoModel newModel = new InfoModel();

            JObject infoJson = JObject.Parse(args.Result);
            newModel.User = infoJson["user"].ToString();
            newModel.Plan = infoJson["plan"].ToString();

            foreach(JToken framework in infoJson["frameworks"].Children())
            {
                newModel.Frameworks.Add(framework.First["name"].ToString());
            }

            newModel.Apps = (int) infoJson["usage"]["apps"];
            newModel.MemoryUsed = (int) infoJson["usage"]["memory"];
            newModel.TotalMemory = (int) infoJson["limits"]["memory"];



            InfoModel = newModel;
            Loading = false;
            Loaded = true;
        }

        #endregion

        #region fields

        private InfoModel _infoModel;
        private RelayCommand<string> _getInfoCommand;
        private string _appFogToken;
        private bool _loading;
        private bool _loaded;

        #endregion



    }
}