using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using AppFogWP7.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.ViewModelUnitTests
{
    [TestClass]
    public class MainViewModelUnitTests
    {
        [TestMethod]
        public void MainViewModelCanNavigate()
        {
            MainViewModel mainViewModel = new MainViewModel();
            mainViewModel.GoToPage("a_page");
            mainViewModel.CanNavigate = true;
        }

        [TestMethod]
        public void MainViewModelSavesAuthToken()
        {
            MainViewModel mainViewModel = new MainViewModel();
            mainViewModel.SaveAuthToken("a_token");
            Assert.IsTrue(mainViewModel.IsTokenSaved);
        }
    }
}
