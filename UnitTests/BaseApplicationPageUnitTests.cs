using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Navigation;
using AppFogWP7;
using AppFogWP7.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class BaseApplicationPageUnitTests
    {
        private BaseApplicationPage _basePage;
        [TestInitialize]
        public void Initialise()
        {
            _basePage = new BaseApplicationPage();
        }

        [TestMethod]
        public void CanRegisterOnNavigatedTo()
        {
            _basePage.NavigateTo(new NavigationEventArgs(null, new Uri("/Page.xaml")));
            Assert.IsTrue(_basePage.Registered);
        }

        [TestMethod]
        public void CanUnegisterOnNavigatedFrom()
        {
            _basePage.NavigateFrom(new NavigationEventArgs(null, new Uri("/Page.xaml")));
            Assert.IsFalse(_basePage.Registered);
        }

        [TestMethod]
        public void PageNavigatedMessageStoredOnNavigatedToMessage()
        {
            _basePage.NavigateTo(new NavigationEventArgs(null, new Uri("/Page.xaml")));
            Assert.AreEqual(new PageNavigatedMessage(this, null, new Uri("/Page.xaml")), _basePage.Message);
        }

        [TestMethod]
        public void PageNavigatedMessageStoredOnNavigatedFromMessage()
        {
            _basePage.NavigateFrom(new NavigationEventArgs(null, new Uri("/Page.xaml")));
            Assert.AreEqual(new PageNavigatedMessage(this, null, new Uri("/Page.xaml")), _basePage.Message);
        }
    }
}
