using System;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using AppFogWP7.DataService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class WebClientUnitTests
    {
        private MyWebClient _client;

        [TestInitialize]
        public void Initialise()
        {
            _client = new MyWebClient();
        }

        [TestMethod]
        public void MyWebClientReceivesCorrectAuthHeader()
        {
            _client.AuthHeader = "AuthHeader";
            Assert.AreEqual("AuthHeader", _client.AuthHeader);
            Assert.AreEqual("AuthHeader", _client.Client.Headers[HttpRequestHeader.Authorization]);
            Assert.AreEqual(_client.AuthHeader, _client.Client.Headers[HttpRequestHeader.Authorization]);
        }
        
        [TestMethod]
        public void MyWebClientReturnsNewWebClient()
        {
            Assert.AreEqual(new WebClient(), _client.Client);
        }
    }
}
