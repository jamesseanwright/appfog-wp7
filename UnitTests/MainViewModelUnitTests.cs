using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using AppFogWP7.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class MainViewModelUnitTests
    {
        [TestMethod]
        public void InfoModelIsAvailableWhenPopulated()
        {
            MainViewModel mainViewModel = new MainViewModel();
            mainViewModel.GetInfo("a_token");
            Assert.IsTrue(mainViewModel.IsInfoModelAvailable);
        }
    }
}
