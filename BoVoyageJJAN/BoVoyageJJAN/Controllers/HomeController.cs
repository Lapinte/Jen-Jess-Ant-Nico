using BoVoyageJJAN.Filter;
using BoVoyageJJAN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageJJAN.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [AuthenticationUserFilter]
        public ActionResult Contact()
        {
            return View();
        }

        // POST: Home/Contact
        /*[AuthenticationUserFilter]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Contact([Bind(Include = "ID,Mail")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Configuration.ValidateOnSaveEnabled = false;

                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                DisplayMessage("Votre demande a bien été envoyée " + customer.Firstname + ". Elle sera traitée dans les meilleurs délais.", MessageType.SUCCESS);
                return RedirectToAction("Index");
            }

            return View(customer);
        }*/


    }
}