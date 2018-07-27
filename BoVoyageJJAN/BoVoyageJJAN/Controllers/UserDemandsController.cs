using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoVoyageJJAN.Data;
using BoVoyageJJAN.Models;

namespace BoVoyageJJAN.Controllers
{
    public class UserDemandsController : BaseController
    {
        // GET: Home/Contact
        public ActionResult Contact()
        {
            return View();
        }

        // POST: Home/Contact
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "ID,Lastname,Firstname,Mail,Demand")] UserDemand userDemand)
        {
            if (ModelState.IsValid)
            {
                db.UserDemands.Add(userDemand);
                db.SaveChanges();
                DisplayMessage("Votre demande a bien été envoyée " + userDemand.Firstname + ". Elle sera traitée dans les meilleurs délais.", MessageType.SUCCESS);
                return RedirectToAction("Index, Home");
            }

            return View();
        }
    }
}
