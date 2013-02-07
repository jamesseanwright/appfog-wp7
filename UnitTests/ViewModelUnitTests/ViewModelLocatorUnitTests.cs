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
            Assert.IsInstanceOfType(_locator.InfoViewModel, typeof(InfoViewModel));
            Assert.IsInstanceOfType(_locator.AppsViewModel, typeof(AppsViewModel));
            Assert.IsInstanceOfType(_locator.MainViewModel, typeof(MainViewModel));
        }

        [TestMethod]
        public void RegistersViewModels()
        {
            Assert.IsTrue(_locator.Registered);
        }

        [TestMethod]
        public void MainPropertyReturnsCurrentMainViewModel()
        {
            Assert.IsInstanceOfType(_locator.MainViewModel, typeof(MainViewModel));
        }
    }
}
