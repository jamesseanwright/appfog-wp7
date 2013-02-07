/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:AppFogWP7"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace AppFogWP7.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel { get; set; }
        public InfoViewModel InfoViewModel { get; set; }
        public AppsViewModel AppsViewModel { get; set; }
        public bool Registered { get; set; }

        public ViewModelLocator()
        {
            MainViewModel = new MainViewModel();
            InfoViewModel = new InfoViewModel();
            AppsViewModel = new AppsViewModel();

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<InfoViewModel>();
            SimpleIoc.Default.Register<AppsViewModel>();
            Registered = true;
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
    }
}