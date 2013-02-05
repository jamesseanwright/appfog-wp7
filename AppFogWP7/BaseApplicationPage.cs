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
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Controls;


namespace AppFogWP7
{
    public class BaseApplicationPage : PhoneApplicationPage
    {
        public void NavigateTo(Uri uri)
        {
            NavigationService.Navigate(uri);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs args)
        {
            Messenger.Default.Unregister<Uri>(this);
        }

        protected override void OnNavigatedTo(NavigationEventArgs args)
        {
            Messenger.Default.Register<Uri>(this, "NavigationRequest", NavigateTo);
        }
    }
}
