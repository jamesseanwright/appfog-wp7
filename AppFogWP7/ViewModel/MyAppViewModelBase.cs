using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Controls;

namespace AppFogWP7.ViewModel
{
    public class MyAppViewModelBase : ViewModelBase
    {
        private bool _loading;
        public bool Loading
        {
            get { return _loading; }
            set
            {
                _loading = value;
                RaisePropertyChanged("Loading");
            }
        }

        private bool _isModelAvailable;
        public bool IsModelAvailable
        {
            set
            {
                _isModelAvailable = value;
                RaisePropertyChanged("IsModelAvailable");
            }
            get { return _isModelAvailable; }
        }
    }
}
