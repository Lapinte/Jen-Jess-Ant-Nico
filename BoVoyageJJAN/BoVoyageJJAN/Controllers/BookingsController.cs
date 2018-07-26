using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoVoyageJJAN.Data;
using BoVoyageJJAN.Filter;
using BoVoyageJJAN.Models;

namespace BoVoyageJJAN.Controllers
{
    public class BookingsController : BaseController
    {


        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Mail");
            ViewBag.TripID = new SelectList(db.Trips, "ID", "ID");

            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthenticationCustomerFilter]
        public ActionResult Create([Bind(Include = "ID,CreditCardNumber,TotalPrice,Insurance,ParticipantNumber,ParticipantUnderTwelveNumber,CreatedAt,CustomerID,TripID")] Reservation reservation)
        {
            /* var old= db.Reservations.SingleOrDefault(x => x.ID == reservation.ID);
             reservation.CreatedAt = old.CreatedAt;
             db.Entry(old).State = EntityState.Detached;*/


            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return View();
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Mail", reservation.CustomerID);
            ViewBag.TripID = new SelectList(db.Trips, "ID", "ID", reservation.TripID);
            
            return View();
        }
        public ActionResult AddParticipant(int? id, Participant participant)
        {
            if (ModelState.IsValid)
            {

                db.Participants.Add(participant);
                db.SaveChanges();
                return View();
            }
            ViewBag.ReservationID = new SelectList(db.Reservations, "TotalPrice", "ParticipantNumber", "ParticipantUnderTwelveNumber", "TripID", "ID");
            return View();


        }

        [HttpPost]
        public ActionResult Cancel([Bind(Include = "ID,CreditCardNumber,TotalPrice,Insurance,ParticipantNumber,ParticipantUnderTwelveNumber,CreatedAt,CustomerID,TripID,Statut")] Reservation reservation)
        {

            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                reservation.Statut = 0;
                db.SaveChanges();
                return RedirectToAction("List");
            }

            return RedirectToAction("Index", "Home");



        }
        [HttpPost]
        public ActionResult List(int? id)
        {
            if (id != null)
            {
                var liste = db.Reservations.Include(x => x.CustomerID);
                return View(liste);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}
