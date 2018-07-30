using BoVoyageJJAN.Filter;
using BoVoyageJJAN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageJJAN.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index(TopFiveViewModel model)
        {
            IEnumerable<Trip> cheapList = db.Trips.Include(x=>x.Destination).OrderBy(x => x.Price).Take(5);
            model.TopFiveCheap = cheapList.ToList();
            IEnumerable<Trip> rushList = db.Trips.Include(x => x.Destination).OrderBy(x => x.DepartureDate).Take(5);
            model.TopFiveRush = rushList.ToList();

            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}