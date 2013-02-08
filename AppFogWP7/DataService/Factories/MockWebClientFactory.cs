﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace AppFogWP7.DataService.Factories
{
    public class MockWebClientFactory : IWebClientFactory
    {
        public IWebClient CreateClient()
        {
            return new MockWebClient();
        }
    }
}
