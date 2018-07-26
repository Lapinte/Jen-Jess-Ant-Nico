using BoVoyageJJAN.Areas.BackOffice.Models;
using BoVoyageJJAN.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoVoyageJJAN.Utils;
using BoVoyageJJAN.Filter;
using BoVoyageJJAN.Controllers;

namespace BoVoyageJJAN.Areas.BackOffice.Controllers
{
    public class AuthenticationCustomerController : BaseController
    {
        // GET: AuthenticationCustomer/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: AuthenticationCustomer/Login
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(AuthenticationLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var passwordHash = model.Password.HashMD5();
                var customer = db.Customers.SingleOrDefault(x => x.Mail == model.Login && x.Password == passwordHash);
                if (customer == null)
                {
                    ViewBag.ErrorMessage = "Utilisateur ou mot de passe incorrect.";

                    return View(model);
                }
                else
                {
                    Session.Add("CUSTOMER_BO", customer);
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            return View(model);
        }

        // GET: AuthenticationCustomer/Logout
        [AuthenticationCustomerFilter]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }

}