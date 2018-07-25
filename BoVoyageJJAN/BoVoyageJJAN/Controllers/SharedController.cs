using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageJJAN.Controllers
{
    public class SharedController : BaseController
    {
        // GET: Shared
        public ActionResult TopFiveCheap()
        {
            var cheap = db.Trips.OrderBy(x => x.Price).Take(5);
            return View("_TopFiveCheap", cheap);
        }

        // GET: Shared
        public ActionResult TopFiveRush()
        {
            var rush = db.Trips.OrderByDescending(x => x.DepartureDate).Take(5);
            return View("_TopFiveRush", rush);
        }

        // GET: Shared
        public ActionResult TopFiveCountry()
        {
            
            return View();
        }
    }
}