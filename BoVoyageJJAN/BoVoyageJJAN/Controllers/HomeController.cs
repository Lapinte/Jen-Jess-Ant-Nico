using BoVoyageJJAN.Models;
using System;
using System.Collections.Generic;
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
            var listecheap = db.Trips.OrderBy(x => x.Price).Take(5);


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