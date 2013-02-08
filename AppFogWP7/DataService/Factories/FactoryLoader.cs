using System;
using System.Linq;
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
    public static class FactoryLoader
    {
        public static IWebClientFactory LoadFactory()
        {
            bool isUnitTest = AppDomain.CurrentDomain.GetAssemblies().Any(a => a.FullName.StartsWith("Microsoft.VisualStudio.QualityTools.UnitTestFramework"));

            IWebClientFactory factory;

            if (isUnitTest)
            {
                factory = new MockWebClientFactory();
            }
            else
            {
                factory = new MyWebClientFactory();
            }

            return factory;
        }
    }
}
