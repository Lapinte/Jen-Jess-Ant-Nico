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
            return View();
        }

        // GET: Shared
        public ActionResult TopFiveRush()
        {
            return View();
        }

        // GET: Shared
        public ActionResult TopFiveCountry()
        {
            return View();
        }
    }
}