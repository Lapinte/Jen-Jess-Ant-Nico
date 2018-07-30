using BoVoyageJJAN.Areas.BackOffice.Models;
using BoVoyageJJAN.Controllers;
using BoVoyageJJAN.Filter;
using BoVoyageJJAN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoVoyageJJAN.Data;

namespace BoVoyageJJAN.Areas.BackOffice.Controllers
{
    
    public class DashBoardController : BaseBoController
    {
        // GET: BackOffice/DashBoard
        public ActionResult Index(DashBoardViewModel model)
        {
            DateTime fifteenDaysFromNow = DateTime.Now.AddDays(-15);
            IEnumerable<Reservation> listeReservationEnAttente = db.Reservations.Include(x => x.Trip.Destination).Include(x => x.Customer).Where(x=>x.Statut == 0);
            IEnumerable<Trip> listeVoyagesUrgents = db.Trips.Include(t => t.Agency).Include(t => t.Destination).Where(x => x.DepartureDate >= fifteenDaysFromNow);

            model.Reservations = listeReservationEnAttente.ToList();
            model.Trips = listeVoyagesUrgents.ToList();
            return View(model);
        }
    }
}