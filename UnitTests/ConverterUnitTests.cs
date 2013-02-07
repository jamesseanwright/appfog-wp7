using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using AppFogWP7.Converter;
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
        public void ConvertsInvalidBooleanToTrue()
        {
            bool isTrue = (bool)_inverter.Convert("a string", typeof(bool), null, null);
            Assert.IsTrue(isTrue);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void BoolConvertBackThrowsNotImplementedException()
        {
            bool isTrue = (bool)_inverter.ConvertBack(false, typeof(bool), null, null);
            Assert.Fail();
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

        [TestMethod]
        public void ConvertsInvalidBooleanToVisible()
        {
            Visibility collapsed = (Visibility)_converter.Convert("a string", typeof(Visibility), null, null);
            Assert.AreEqual(Visibility.Visible, collapsed);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void VisibilityConvertBackThrowsNotImplementedException()
        {
            bool isTrue = (bool)_converter.ConvertBack(Visibility.Visible, typeof(bool), null, null);
            Assert.Fail();
        }
    }
}
