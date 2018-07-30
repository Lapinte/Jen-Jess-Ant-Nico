using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoVoyageJJAN.Controllers;
using BoVoyageJJAN.Data;
using BoVoyageJJAN.Models;

namespace BoVoyageJJAN.Areas.BackOffice.Controllers
{
    public class UserDemandsBoController : BaseBoController
    {
        // GET: BackOffice/UserDemandsBo
        public ActionResult Index()
        {
            return View("Index", db.UserDemands.ToList());
        }

        // GET: BackOffice/UserDemandsBo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDemand userDemand = db.UserDemands.Find(id);
            if (userDemand == null)
            {
                return HttpNotFound();
            }
            return View("Details", userDemand);
        }

        // GET: BackOffice/UserDemandsBo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDemand userDemand = db.UserDemands.Find(id);
            if (userDemand == null)
            {
                return HttpNotFound();
            }
            return View("Delete", userDemand);
        }

        // POST: BackOffice/UserDemandsBo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDemand userDemand = db.UserDemands.Find(id);
            db.UserDemands.Remove(userDemand);
            db.SaveChanges();
            DisplayMessage("Demande n°" + userDemand.ID + " supprimée.", MessageType.SUCCESS);
            return RedirectToAction("Index");
        }
    }
}
