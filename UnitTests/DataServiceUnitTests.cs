using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppFogWP7.DataService;
using AppFogWP7.Model;

namespace UnitTests
{
    [TestClass]
    public class DataServiceUnitTests
    {
        [TestMethod]
        public async void ReceivesCorrectData()
        {
            AppFogDataService appFogDataService = new AppFogDataService();

            //passing in a token for a test account. I'll mock this when I find the best way of doing it in Silverlight
            InfoModel infoModel = await appFogDataService.CallAPI("a_token");
            
            Assert.AreEqual("test_user", infoModel.User);
            Assert.AreEqual("test_plan", infoModel.Plan);
            Assert.AreEqual("Test Framework", infoModel.Frameworks.First());
            Assert.AreEqual(1, infoModel.Apps);
            Assert.AreEqual(256, infoModel.MemoryUsed);
            Assert.AreEqual(2048, infoModel.TotalMemory);
        }
    }
}
