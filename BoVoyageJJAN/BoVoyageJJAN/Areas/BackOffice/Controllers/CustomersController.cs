using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
                liste = db.Customers.Where(x => x.Lastname.Contains(model.Lastname));
            if (!string.IsNullOrWhiteSpace(model.Firstname))
                liste = db.Customers.Where(x => x.Firstname.Contains(model.Firstname));
            if (!string.IsNullOrWhiteSpace(model.Mail))
                liste = db.Customers.Where(x => x.Mail.Contains(model.Mail));
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
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
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
    }
}
