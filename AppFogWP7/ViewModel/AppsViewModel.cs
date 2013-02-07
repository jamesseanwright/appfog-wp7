using System.Collections.Generic;
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
        private List<AppModel> _apps;
        public List<AppModel> Apps
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
            _apps = new List<AppModel>();
            GetAppsCommand = new RelayCommand(GetApps);
        }

        public async void GetApps()
        {
            AppFogDataService appFogDataService = new AppFogDataService();
            Apps = await appFogDataService.GetApps(AuthToken);
            Loading = false;
            IsModelAvailable = true;
        }
    }
}