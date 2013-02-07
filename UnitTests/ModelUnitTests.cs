using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using AppFogWP7.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ModelUnitTests
    {
        [TestMethod]
        public void AppModelConstructionCreatesUriList()
        {
            AppModel appModel = new AppModel();
            Assert.AreEqual(0, appModel.Uris.Count);
        }
    }
}
