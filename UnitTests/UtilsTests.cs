using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppFogWP7.Utils;

namespace UnitTests
{
    [TestClass]
    public class UtilsTests
    {
        [TestMethod]
        public void TimestampConvertedToDate()
        {
            DateTime date = new DateTime(2013, 2, 6, 16, 0, 0);
            Assert.AreEqual(date, DateUtils.TimeStampToDateTime(1360195200.0));
        }
    }
}
