﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoVoyageJJAN.Data;
using BoVoyageJJAN.Filter;
using BoVoyageJJAN.Models;
using BoVoyageJJAN.Utils;

namespace BoVoyageJJAN.Controllers
{
    public class AccountsController : BaseController
    {
        // GET: Accounts/Details
        /*[AuthenticationUserFilter]
        public ActionResult Details()
        {
            Customer customer = db.Customers.Include(c => c.Civility).SingleOrDefault(x => x. == model.Login);
            return View(customer);
        }*/

        // GET: Accounts/Create
        public ActionResult Create()
        {
            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Mail,Password,ConfirmedPassword,Lastname,Firstname,Address,Phone,BirthDate,CivilityID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                customer.Password = customer.Password.HashMD5();

                db.Customers.Add(customer);
                db.SaveChanges();
                DisplayMessage("Votre compte est bien créé ! Bienvenue " + customer.Firstname + " !", MessageType.SUCCESS);
                return RedirectToAction("Index");
            }

            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label", customer.CivilityID);
            return View(customer);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label", customer.CivilityID);
            return View(customer);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Lastname,Firstname,Password,Address,Phone,BirthDate,CivilityID")] Customer customer)
        {

            var old = db.Customers.SingleOrDefault(x => x.ID == customer.ID);
            customer.Mail = old.Mail;
            db.Entry(old).State = EntityState.Detached;

            if (ModelState.IsValid)
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                customer.Password = customer.Password.HashMD5();

                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                DisplayMessage("Modifications enregistrées", MessageType.SUCCESS);
                return RedirectToAction("Index");
            }
            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label", customer.CivilityID);
            return View(customer);
        }
    }
}
