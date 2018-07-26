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
    public class CustomersController : BaseController
    {
        // GET: Customers
        //[AuthenticationCommercialFilter]
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.Civility);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        //[AuthenticationCommercialFilter]
        public ActionResult Details(int? id)
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
            return View(customer);
        }
        // GET: Customers/Search
        //[AuthenticationCommercialFilter]
        public IQueryable<Customer> GetSearch(string mail = "", string lastname = "", string firstname = "", string phone = "", string address = "", int? customerID = null)
        {
            var query = db.Customers.Where(x => x.ID > 0);

            if (customerID != null)
                query = query.Where(x => x.ID == customerID);
            if (!string.IsNullOrWhiteSpace(mail))
                query = query.Where(x => x.Mail.Contains(mail));
            if (!string.IsNullOrWhiteSpace(lastname))
                query = query.Where(x => x.Lastname.Contains(lastname));
            if (!string.IsNullOrWhiteSpace(firstname))
                query = query.Where(x => x.Firstname.Contains(firstname));
            if (!string.IsNullOrWhiteSpace(phone))
                query = query.Where(x => x.Phone.Contains(phone));
            if (!string.IsNullOrWhiteSpace(address))
                query = query.Where(x => x.Address.Contains(address));

            return query;
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label");
            return View();
        }

        // POST: Customers/Create
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
                return RedirectToAction("Index");
            }

            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label", customer.CivilityID);
            return View(customer);
        }

        // GET: Customers/Edit/5
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

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Mail,Password,Lastname,Firstname,Address,Phone,BirthDate,CivilityID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label", customer.CivilityID);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
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
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
