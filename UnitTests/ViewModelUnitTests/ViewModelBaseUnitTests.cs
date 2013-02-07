using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using AppFogWP7.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.ViewModelUnitTests
{
    [TestClass]
    public class ViewModelBaseUnitTests
    {
        private MyAppViewModelBase _base = new MyAppViewModelBase();
        [TestMethod]
        public void LoadingIsTrueOnConstruction()
        {
            Assert.IsTrue(_base.Loading);
        }
    }
}
