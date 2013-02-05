using System;
using System.Windows.Input;
using System.Windows.Navigation;
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
        public RelayCommand<string> SaveAuthTokenCommand { get; private set; }
        public RelayCommand<string> GoToPageCommand { get; private set; }
        
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
            SaveAuthTokenCommand = new RelayCommand<string>(SaveAuthToken);
            GoToPageCommand = new RelayCommand<string>(GoToPage);
        }

        public void SaveAuthToken(string token)
        {
            (App.Current as App).AuthToken = token;
            IsTokenSaved = true;
        }

        public void GoToPage(string page)
        {
            try
            {
                Messenger.Default.Send(new Uri("/" + page + "Page.xaml", UriKind.Relative), "NavigationRequest");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}