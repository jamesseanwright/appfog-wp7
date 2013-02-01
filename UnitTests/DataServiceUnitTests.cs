using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppFogWP7.DataService;
using AppFogWP7.Model;
using System.Threading;

namespace UnitTests
{
    [TestClass]
    public class DataServiceUnitTests
    {
        [TestMethod]
        public async void RetrievesCorrectData()
        {
            AppFogDataService appFogDataService = new AppFogDataService();

            //passing in a token for a test account. I'll mock this when I find the best way of doing it in Silverlight
            InfoModel infoModel = await appFogDataService.CallAPI("04085b0849221b6a616d65732e7772696768744062736b79622e636f6d063a0645466c2b077d2815512219375364d09677701f82765e66e3d728c6b05c6fe8");
            
            Assert.AreSame(1, infoModel.Apps); 
        }
    }
}
