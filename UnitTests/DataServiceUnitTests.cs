using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Silverlight.Testing;
using Microsoft.Silverlight.Testing.UnitTesting.Metadata.VisualStudio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppFogWP7.DataService;
using AppFogWP7.Model;
using AppFogWP7.Utils;
using System.Collections.ObjectModel;

namespace UnitTests
{
    [TestClass]
    public class DataServiceUnitTests
    {
        private AppFogDataService _appFogDataService;

        [TestInitialize]
        public void Initialise()
        {
            _appFogDataService = new AppFogDataService();
        }

        [TestMethod]
        public async void ReceivesCorrectInfoData()
        {
            InfoModel infoModel = await _appFogDataService.GetInfo("token");
            
            Assert.AreEqual("test_user", infoModel.User);
            Assert.AreEqual("test_plan", infoModel.Plan);
            Assert.AreEqual("Test Framework", infoModel.Frameworks.First());
            Assert.AreEqual(1, infoModel.Apps);
            Assert.AreEqual(256, infoModel.MemoryUsed);
            Assert.AreEqual(2048, infoModel.TotalMemory);
        }

        [TestMethod]
        public async void ReceivesCorrectAppsData()
        {            
            var appModels = await _appFogDataService.GetApps("token");
            
            AppModel appModel = appModels.First();

            Assert.AreEqual("test_app", appModel.Name);
            Assert.AreEqual(1, appModel.Instances);
            Assert.AreEqual("test_stack", appModel.Stack);
            Assert.AreEqual(256, appModel.Memory);
            Assert.AreEqual("jamesswright.eu01.aws.af.cm", appModel.Uris.First());
            Assert.AreEqual(DateUtils.TimeStampToDateTime(1359854226.0), appModel.Created);
        }
    }
}
