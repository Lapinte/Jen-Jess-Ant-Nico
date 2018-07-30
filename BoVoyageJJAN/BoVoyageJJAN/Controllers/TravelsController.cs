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
        public ActionResult Index(TravelSearchViewModel model)
        {
            IEnumerable<Trip> liste = db.Trips.Include(t => t.Agency).Include(t => t.Destination);
            if (model.Destination != null)
                liste = liste.Where(x => x.Destination.Country.ToLower().Contains(model.Destination.ToLower()));
            if (model.MaxPrice != null)
                liste = liste.Where(x => x.Price <= model.MaxPrice);
            if (model.MinPrice != null)
                liste = liste.Where(x => x.Price >= model.MinPrice);
            if (model.MaxDate != null)
                liste = liste.Where(x => x.ReturnDate <= model.MaxDate);
            if (model.MinDate != null)
                liste = liste.Where(x => x.DepartureDate >= model.MinDate);

            model.Trips = liste.ToList();
            return View(model);
        }

        // GET: Travels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = db.Trips.Include(x => x.Agency).Include(x => x.Destination).SingleOrDefault(x => x.ID == id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }
              
    }
}
