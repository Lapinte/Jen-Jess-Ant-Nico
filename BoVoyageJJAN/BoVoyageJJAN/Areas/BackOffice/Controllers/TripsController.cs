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

namespace BoVoyageJJAN.Areas.BackOffice.Controllers
{
    public class TripsController : Controller
    {
        private JjanDbContext db = new JjanDbContext();

        // GET: BackOffice/Trips
        public ActionResult Index(TripSearchViewModel model)
        {
            if (model == null)
            {
                var trips = db.Trips.Include(t => t.Agency).Include(t => t.Destination);
                return View(trips.ToList());
            }
            IEnumerable<Trip> liste = db.Trips.Include(t => t.Agency).Include(t => t.Destination);
            if ()
        }
        


        // GET: BackOffice/Trips/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = db.Trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // GET: BackOffice/Trips/Create
        public ActionResult Create()
        {
            ViewBag.AgencyID = new SelectList(db.Agencies, "ID", "Name");
            ViewBag.DestinationID = new SelectList(db.Destinations, "ID", "Continent");
            return View();
        }

        // POST: BackOffice/Trips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DepartureDate,ReturnDate,PlaceNumber,Price,DestinationID,AgencyID")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Trips.Add(trip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgencyID = new SelectList(db.Agencies, "ID", "Name", trip.AgencyID);
            ViewBag.DestinationID = new SelectList(db.Destinations, "ID", "Continent", trip.DestinationID);
            return View(trip);
        }

        // GET: BackOffice/Trips/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = db.Trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgencyID = new SelectList(db.Agencies, "ID", "Name", trip.AgencyID);
            ViewBag.DestinationID = new SelectList(db.Destinations, "ID", "Continent", trip.DestinationID);
            return View(trip);
        }

        // POST: BackOffice/Trips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DepartureDate,ReturnDate,PlaceNumber,Price,DestinationID,AgencyID")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgencyID = new SelectList(db.Agencies, "ID", "Name", trip.AgencyID);
            ViewBag.DestinationID = new SelectList(db.Destinations, "ID", "Continent", trip.DestinationID);
            return View(trip);
        }

        //GET: Trips/Search
        public ActionResult Search(DateTime? departureDate = null, DateTime? returnDate = null, int? placeNumber = null, decimal? price = null, int? destinationId = null, int? agencyId = null)
        {
            IQueryable<Trip> liste = db.Trips;
            if (departureDate != null)
                liste = liste.Where(x => x.DepartureDate == returnDate);
            if (returnDate != null)
                liste = liste.Where(x => x.ReturnDate == returnDate);
            if (placeNumber != null)
                liste = liste.Where(x => x.PlaceNumber == placeNumber);
            if (price != null)
                liste = liste.Where(x => x.Price == price);
            if (destinationId != null)
                liste = liste.Where(x => x.DestinationID == destinationId);
            if (agencyId != null)
                liste = liste.Where(x => x.AgencyID == agencyId);

            return View("Index", liste);
        }

        // GET: BackOffice/Trips/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = db.Trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // POST: BackOffice/Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trip trip = db.Trips.Find(id);
            db.Trips.Remove(trip);
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
