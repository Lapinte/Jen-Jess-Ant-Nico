using System;
using System.Web.Mvc;
using BoVoyageJJAN.Areas.BackOffice.Controllers;
using BoVoyageJJAN.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoVoyageJJAN.Tests
{
    [TestClass]
    public class UserDemandsBoTest
    {
        [TestMethod]
        public void TestIndexView()
        {
            var controller = new UserDemandsBoController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void TestDetailsView()
        {
            var controller = new UserDemandsBoController();
            var result = controller.Details(3) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void TestDetailsViewData()
        {
            var controller = new UserDemandsBoController();
            var result = controller.Details(3) as ViewResult;
            var userDemand = (UserDemand)result.ViewData.Model;
            Assert.AreEqual(3, userDemand.ID);
        }

        [TestMethod]
        public void TestDeleteView()
        {
            var controller = new UserDemandsBoController();
            var result = controller.Delete(3) as ViewResult;
            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void TestDeleteViewData()
        {
            var controller = new UserDemandsBoController();
            var result = controller.Delete(3) as ViewResult;
            var userDemand = (UserDemand)result.ViewData.Model;
            Assert.AreEqual(3, userDemand.ID);
        }
    }
}
