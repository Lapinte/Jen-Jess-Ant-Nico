using BoVoyageJJAN.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageJJAN.Areas.BackOffice.Controllers
{
    public class SharedController : BaseController
    {
        // GET: BackOffice/SharedBO
        [ChildActionOnly]
        public ActionResult PendingReservation()
        {
            var pendingRersevation = db.Reservations.Where(x => x.Statut == 0).ToList();
            return View("_PendingReservation", pendingRersevation);
        }
    }
}