using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppFogWP7.ViewModel;

namespace UnitTests
{
    [TestClass]
    public class ConverterUnitTests
    {
        private BooleanInverter _inverter;
        private BooleanToVisibilityConverter _converter;

        [TestInitialize]
        public void Setup()
        {
            _inverter = new BooleanInverter();
            _converter = new BooleanToVisibilityConverter();
        }

        [TestMethod]
        public void ConvertsTrueToFalse()
        {
            bool isFalse = (bool) _inverter.Convert(true, typeof (bool), null, null);
            Assert.IsFalse(isFalse);
        }

        [TestMethod]
        public void ConvertsFalseToTrue()
        {
            bool isTrue = (bool) _inverter.Convert(false, typeof(bool), null, null);
            Assert.IsTrue(isTrue);
        }

        [TestMethod]
        public void ConvertsTrueToVisible()
        {
            Visibility visible = (Visibility) _converter.Convert(true, typeof (Visibility), null, null);
            Assert.AreEqual(Visibility.Visible, visible);
        }

        [TestMethod]
        public void ConvertsFalseToCollapsed()
        {
            Visibility collapsed = (Visibility)_converter.Convert(false, typeof(Visibility), null, null);
            Assert.AreEqual(Visibility.Collapsed, collapsed);
        }
    }
}
