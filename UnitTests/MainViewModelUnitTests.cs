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
            InfoViewModel mainViewModel = new InfoViewModel();
            Assert.IsTrue(mainViewModel.IsInfoModelAvailable);
        }
    }
}
