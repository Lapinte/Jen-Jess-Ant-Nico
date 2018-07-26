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

namespace BoVoyageJJAN.Areas.BackOffice.Controllers
{
    public class CustomersController : Controller
    {
        private JjanDbContext db = new JjanDbContext();

        // GET: BackOffice/CustomersBO
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.Civility);
            return View(customers.ToList());
        }

        // GET: BackOffice/CustomersBO/Details/5
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

        // GET: BackOffice/CustomersBO/Create
        public ActionResult Create()
        {
            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label");
            return View();
        }

        // POST: BackOffice/CustomersBO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Mail,Password,Lastname,Firstname,Address,Phone,BirthDate,CivilityID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CivilityID = new SelectList(db.Civilities, "ID", "Label", customer.CivilityID);
            return View(customer);
        }

        // GET: BackOffice/CustomersBO/Edit/5
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

        // POST: BackOffice/CustomersBO/Edit/5
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
        public ActionResult GetSearch(string Lastname ="", string Firstname ="", string Address="", string Phone="", string Mail="", DateTime? BirthDate =null)
        {
            IQueryable<Customer> liste = db.Customers;
            if (!string.IsNullOrWhiteSpace(Lastname))
                liste = liste.Where(x => x.Lastname.Contains(Lastname));
            if (!string.IsNullOrWhiteSpace(Firstname))
                liste = liste.Where(x => x.Firstname.Contains(Firstname));
            if (!string.IsNullOrWhiteSpace(Address))
                liste = liste.Where(x => x.Address.Contains(Address));
            if (!string.IsNullOrWhiteSpace(Phone))
                liste = liste.Where(x => x.Phone.Contains(Phone));
            if (!string.IsNullOrWhiteSpace(Mail))
                liste = liste.Where(x => x.Mail.Contains(Mail));
            if (BirthDate != null)
                liste = liste.Where(x => x.BirthDate == BirthDate);

            return View("Index",liste);
        }

        // GET: BackOffice/CustomersBO/Delete/5
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

        // POST: BackOffice/CustomersBO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
