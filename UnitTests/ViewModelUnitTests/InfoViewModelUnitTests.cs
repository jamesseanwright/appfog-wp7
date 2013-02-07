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
    public class InfoViewModelUnitTests
    {
        private InfoViewModel _infoViewModel;

        [TestInitialize]
        public void Initialise()
        {
            _infoViewModel = new InfoViewModel();
        }

        [TestMethod]
        public void InfoModelIsAvailableWhenPopulated()
        {
            InfoViewModel _infoViewModel = new InfoViewModel();
            _infoViewModel.GetInfo();
            Assert.IsTrue(_infoViewModel.IsModelAvailable);
        }

        [TestMethod]
        public void ReturnsNewInfoModel()
        {
            Assert.IsInstanceOfType(_infoViewModel.InfoModel, typeof(InfoModel));
        }

        [TestMethod]
        public void ReturnsGetInfoCommand()
        {
            Assert.IsNotNull(_infoViewModel.GetInfoCommand);
        }
    }
}
