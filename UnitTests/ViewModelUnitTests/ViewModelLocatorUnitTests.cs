using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using AppFogWP7.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ViewModelLocatorUnitTests
    {
        private ViewModelLocator _locator;

        [TestInitialize]
        public void Initialise()
        {
            _locator = new ViewModelLocator();
        }

        [TestMethod]
        public void CreatesViewModelInstances()
        {
            
            Assert.AreEqual(new MainViewModel(), _locator.MainViewModel);
            Assert.AreEqual(new InfoViewModel(), _locator.InfoViewModel);
            Assert.AreEqual(new AppsViewModel(), _locator.AppsViewModel);
        }

        [TestMethod]
        public void RegistersViewModels()
        {
            Assert.IsTrue(_locator.Registered);
        }

        [TestMethod]
        public void MainPropertyReturnsCurrentMainViewModel()
        {
            Assert.AreEqual(new MainViewModel(), _locator.Main);
        }
    }
}
