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
    public class AuthenticationCommercialController : BaseController
    {
        // GET: BackOffice/AuthenticationCommercial/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: BackOffice/AuthenticationCommercial/Login
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(AuthenticationLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var passwordHash = model.Password.HashMD5();
                var commercial = db.Commercials.SingleOrDefault(x => x.Mail == model.Login && x.Password == passwordHash);
                if (commercial == null)
                {
                    ViewBag.ErrorMessage = "Utilisateur ou mot de passe incorrect.";

                    return View(model);
                }
                else
                {
                    Session.Add("COMMERCIAL_BO", commercial);
                    return RedirectToAction("Index", "Dashboard", new { area = "BackOffice" });
                }
            }
            return View(model);
        }

        // GET: BackOffice/Authentication/Logout
        [AuthenticationFilter]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }

}