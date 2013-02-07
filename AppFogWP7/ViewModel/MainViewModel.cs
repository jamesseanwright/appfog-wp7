using System;
using System.Windows.Input;
using System.Windows.Navigation;
using AppFogWP7.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace AppFogWP7.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class MainViewModel : MyAppViewModelBase
    {
        public RelayCommand<string> SaveAuthTokenCommand { get; set; }
        public RelayCommand<string> GoToPageCommand { get; set; }
        public bool CanNavigate { get; set; }
        
        private bool _isTokenSaved;
        public bool IsTokenSaved
        {
            get { return _isTokenSaved; }
            set 
            { 
                _isTokenSaved = value;
                RaisePropertyChanged("IsTokenSaved");
            }
        }

        public MainViewModel()
        {
            CanNavigate = true;
            SaveAuthTokenCommand = new RelayCommand<string>(SaveAuthToken);
            GoToPageCommand = new RelayCommand<string>(GoToPage);
        }

        public void SaveAuthToken(string token)
        {
            AuthToken = token;
            IsTokenSaved = true;
        }

        public void GoToPage(string page)
        {
            PageNavigatedMessage message = new PageNavigatedMessage(this, null, new Uri("/" + page + "Page.xaml", UriKind.Relative));

            try
            {
                Messenger.Default.Send(message);
            }
            catch
            {
                CanNavigate = false;
            }
        }
    }
}