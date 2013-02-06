using System.Collections.ObjectModel;
using AppFogWP7.DataService;
using AppFogWP7.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

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
    public class AppsViewModel : MyAppViewModelBase
    {
        private ObservableCollection<AppModel> _apps;
        public ObservableCollection<AppModel> Apps
        {
            get { return _apps; }
            set
            {
                _apps = value;
                RaisePropertyChanged("Apps");
            }
        }

        public RelayCommand GetAppsCommand { get; set; }

        public AppsViewModel()
        {
            _apps = new ObservableCollection<AppModel>();
            GetAppsCommand = new RelayCommand(GetApps);
        }

        public async void GetApps()
        {
            Loading = true;
            AppFogDataService appFogDataService = new AppFogDataService();
            Apps = await appFogDataService.GetApps();
            Loading = false;
            IsModelAvailable = true;
        }
    }
}