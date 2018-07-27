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
            //IEnumerable<Trip> tempList = db.Trips.Include(x => x.Destination);
            //IEnumerable<IGrouping<string, string>> countryList= tempList.GroupBy(x=>x.Destination.Country)


            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        [AuthenticationUserFilter]
        public ActionResult Contact()
        {
            return View();
        }

        // POST: Home/Contact
        /*[AuthenticationUserFilter]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Contact([Bind(Include = "ID,Mail")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Configuration.ValidateOnSaveEnabled = false;

                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                DisplayMessage("Votre demande a bien été envoyée " + customer.Firstname + ". Elle sera traitée dans les meilleurs délais.", MessageType.SUCCESS);
                return RedirectToAction("Index");
            }

            return View(customer);
        }*/


    }
}