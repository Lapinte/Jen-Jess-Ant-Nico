using System;
using System.Web.Mvc;
using BoVoyageJJAN.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoVoyageJJAN.Tests
{
    [TestClass]
    public class UserDemandsTest
    {
        [TestMethod]
        public void TestContactView()
        {
            var controller = new UserDemandsController();
            var result = controller.Contact() as ViewResult;
            Assert.AreEqual("Contact", result.ViewName);
        }
    }
}
