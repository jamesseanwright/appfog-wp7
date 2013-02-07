using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;

namespace AppFogWP7.Messages
{
    public class PageNavigatedMessage : MessageBase
    {
        public Uri Uri { get; set; }

        public PageNavigatedMessage(object sender, object target, Uri uri)
        {
            Sender = sender;
            Target = target;
            Uri = uri;
        }
    }
}
