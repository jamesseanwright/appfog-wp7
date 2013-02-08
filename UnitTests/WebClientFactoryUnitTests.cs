using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using AppFogWP7.DataService;
using AppFogWP7.DataService.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class WebClientFactoryUnitTests
    {
        [TestMethod]
        public void ReturnsMockClientIfUnitTest()
        {
            IWebClientFactory factory = FactoryLoader.LoadFactory();
            IWebClient client = factory.CreateClient();
            Assert.IsInstanceOfType(client, typeof(MockWebClient));
        }
    }
}
