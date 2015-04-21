using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CCTV.Controllers;
using System.Web.Mvc;

namespace Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Result_IndexAction_ItsOkView()
        {
            var controller = new HomeController();
            var result = controller.Index();
            Assert.AreEqual(result, "");
        }
    }
}
