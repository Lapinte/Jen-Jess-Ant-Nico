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
    public class TravelsController : BaseController
    {
        // GET: Travels
        public ActionResult Index()
        {
            var travels = db.Trips.Include(t => t.Agency).Include(t => t.Destination);
            return View(travels.ToList());
        }

        // GET: Travels/Details/5
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


        //GET: Travels/Search
        public IQueryable<Trip> GetSearch(DateTime? departureDate = null, DateTime? returnDate = null, int? placeNumber = null, decimal? price = null, int? destinationId = null, int? agencyId = null)
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

            return liste;
        }
      
    }
}
