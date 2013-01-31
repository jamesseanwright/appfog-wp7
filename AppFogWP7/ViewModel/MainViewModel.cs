using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight;
using AppFogWP7.Model;
using System.Net;
using GalaSoft.MvvmLight.Command;

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
            _getInfoCommand = new RelayCommand<string>(GetInfo);
        }

        #region properties

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

        public string AppFogToken { get; set; }

        #endregion

        #region methods
        public void GetInfo(string token)
        {
            Loading = true;
        }
        #endregion

        #region fields

        private InfoModel _infoModel;
        private RelayCommand<string> _getInfoCommand;
        private string _appFogToken;
        private bool _loading;

        #endregion



    }
}