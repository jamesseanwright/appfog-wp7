using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using AppFogWP7.Model;
using AppFogWP7.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.ViewModelUnitTests
{
    [TestClass]
    public class AppViewModelUnitTests
    {
        [TestMethod]
        public void AppsModelIsAvailableWhenPopulated()
        {
            AppsViewModel appsViewModel = new AppsViewModel();
            appsViewModel.GetApps();
            Assert.IsTrue(appsViewModel.IsModelAvailable);
        }

        [TestMethod]
        public void AppsModelHasListObject()
        {
            AppsViewModel appsViewModel = new AppsViewModel();
            Assert.IsInstanceOfType(appsViewModel.Apps, typeof(List<AppModel>));
        }
    }
}
