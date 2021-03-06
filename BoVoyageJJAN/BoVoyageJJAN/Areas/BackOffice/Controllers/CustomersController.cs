﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BoVoyageJJAN.Areas.BackOffice.Models;
using BoVoyageJJAN.Data;
using BoVoyageJJAN.Models;
using BoVoyageJJAN.Utils;

namespace BoVoyageJJAN.Areas.BackOffice.Controllers
{
    public class CustomersController : BaseBoController
    {
        // GET: BackOffice/Customers

        public ActionResult Index(CustomerSearchViewModel model)
        {

            IEnumerable<Customer> liste = db.Customers.Include(c => c.Civility);
            if (!string.IsNullOrWhiteSpace(model.Lastname))
                liste = liste.Where(x => x.Lastname.ToLower().Contains(model.Lastname));
            if (!string.IsNullOrWhiteSpace(model.Firstname))
                liste = liste.Where(x => x.Firstname.ToLower().Contains(model.Firstname));
            if (!string.IsNullOrWhiteSpace(model.Mail))
                liste = liste.Where(x => x.Mail.ToLower().Contains(model.Mail));
            if (model.BirthDateMin != null)
                liste = liste.Where(x => x.BirthDate >= model.BirthDateMin);
            if (model.BirthDateMax != null)
                liste = liste.Where(x => x.BirthDate <= model.BirthDateMax);

            model.Customers = liste.ToList();
            return View(model);
        }

        // GET: BackOffice/Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Include(x => x.Civility).SingleOrDefault(x => x.ID == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: BackOffice/Customers/Create
        public ActionResult Create()
        {
            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label");
            return View();
        }

        // POST: BackOffice/Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Mail,Password,Lastname,Firstname,Address,Phone,BirthDate,CivilityID,ConfirmedPassword")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                customer.Password = customer.Password.HashMD5();

                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label", customer.CivilityID);
            return View(customer);
        }

        // GET: BackOffice/Customers/Edit/5
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

        // POST: BackOffice/Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Mail,Password,Lastname,Firstname,Address,Phone,BirthDate,CivilityID")] Customer customer)
        {
            ModelState.Remove("Mail");
            ModelState.Remove("Password");
            ModelState.Remove("ConfirmedPassword");
            var old = db.Customers.Find(customer.ID);
            customer.Mail = old.Mail;
            customer.Password = old.Password;
            customer.ConfirmedPassword = old.Password.HashMD5();
            db.Entry(old).State = EntityState.Detached;
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label", customer.CivilityID);
            return View(customer);
        }
        //GET: Customers/Search
        public ActionResult Search()
        {
            return View();
        }

        // GET: BackOffice/Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Include(x => x.Civility).SingleOrDefault(x => x.ID == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: BackOffice/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void DownloadCsv()
        {
            IEnumerable<Customer> customersList = db.Customers.Include(c => c.Civility);
            string CustomersCsv = GetCsvString(customersList);

            // Return the file content with response body. 
            Response.ContentType = "text/csv";
            Response.AddHeader("Content-Disposition", "attachment;filename=Customers.csv");
            Response.Write(CustomersCsv);
            Response.End();
        }

        private string GetCsvString(IEnumerable<Customer> customersList)
        {
            StringBuilder csv = new StringBuilder();

            csv.AppendLine("FirstName;LastName;Email");

            foreach (Customer customer in customersList)
            {
                csv.AppendLine($"{customer.Firstname};{customer.Lastname};{customer.Mail}");
            }

            return csv.ToString();
        }
    }
}
