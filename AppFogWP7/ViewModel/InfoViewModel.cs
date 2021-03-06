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
using AppFogWP7.DataService;

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
    public class InfoViewModel : MyAppViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
 
        public InfoViewModel()
        {
            _getInfoCommand = new RelayCommand(GetInfo);
            _infoModel = new InfoModel();
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

        public RelayCommand GetInfoCommand
        {
            get { return _getInfoCommand; }
        }

        #endregion

        #region methods
        public async void GetInfo()
        {
            AppFogDataService appFogDataService = new AppFogDataService();
            InfoModel = await appFogDataService.GetInfo(AuthToken);
            Loading = false;
            IsModelAvailable = true;
        }

        #endregion

        #region fields

        private InfoModel _infoModel;
        private RelayCommand _getInfoCommand;

        #endregion
    }
}