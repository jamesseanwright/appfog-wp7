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
using AppFogWP7.Messages;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Controls;


namespace AppFogWP7
{
    public class BaseApplicationPage : PhoneApplicationPage
    {
        public bool Navigated { get; set; }
        public bool Registered { get; set; }
        public PageNavigatedMessage Message { get; set; }

        protected override void OnNavigatedFrom(NavigationEventArgs args)
        {
            Messenger.Default.Unregister<PageNavigatedMessage>(this, (m) =>
                                                                         {
                                                                             Message = m;
                                                                             Registered = false;
                                                                         });
        }

        protected override void OnNavigatedTo(NavigationEventArgs args)
        {
            Messenger.Default.Register<PageNavigatedMessage>(this, (m)=>
                                                                       {
                                                                           Message = m;
                                                                           Registered = true;
                                                                           NavigationService.Navigate(m.Uri);
                                                                           Navigated = true;
                                                                       });
        }

        public void NavigateTo(NavigationEventArgs args)
        {
            OnNavigatedTo(args);
        }

        public void NavigateFrom(NavigationEventArgs args)
        {
            OnNavigatedFrom(args);
        }
    }
}
