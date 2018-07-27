﻿using System;
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
    public class BookingsController : BaseController
    {

        // GET: Bookings
        public ActionResult Index(int? id)
        {
            var reservations = db.Reservations.Include(r => r.Customer).Where(x => x.CustomerID == id);
            return View(reservations.ToList());
        }

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
        public ActionResult Create([Bind(Include = "ID,CreditCardNumber,TotalPrice,Insurance,ParticipantNumber,ParticipantUnderTwelveNumber,CreatedAt,Statut,CustomerID,TripID")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Mail", reservation.CustomerID);
            ViewBag.TripID = new SelectList(db.Trips, "ID", "ID", reservation.TripID);
            TempData["Message"] = "Réservation ajoutée";
            return View(reservation);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation =db.Reservations.Include(x => x.Participants).SingleOrDefault(x => x.ID == id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Mail", reservation.CustomerID);
            ViewBag.TripID = new SelectList(db.Trips, "ID", "ID", reservation.TripID);
            return View(reservation);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CreditCardNumber,TotalPrice,Insurance,ParticipantNumber,ParticipantUnderTwelveNumber,CreatedAt,Statut,CustomerID,TripID")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Mail", reservation.CustomerID);
            ViewBag.TripID = new SelectList(db.Trips, "ID", "ID", reservation.TripID);
            return View(reservation);
        }

        // GET: Bookings/Cancel/5
        public ActionResult Cancel([Bind(Include = "ID,CreditCardNumber,TotalPrice,Insurance,ParticipantNumber,ParticipantUnderTwelveNumber,CreatedAt,Statut,CustomerID,TripID")] Reservation reservation)
        {
            if (ModelState.IsValid)

            db.Entry(reservation).State = EntityState.Modified;
            reservation.Statut = 0;
            db.SaveChanges();
            TempData["Message"] = "Réservation annulée";
            return RedirectToAction("Index");

        }



        [HttpPost]
        public ActionResult AddParticipant(int? id, Participant participant)
        {
            if (id == null)
            {
                TempData["Message"] = "Aucun participant";
                return RedirectToAction("Edit", new { id });
            }

            if (participant != null)
            {
                var person = new Participant();

                db.Participants.Add(person);
                db.SaveChanges();
                TempData["Message"] = "participant ajouté";
                return RedirectToAction("Edit", new { id = person.ReservationID });

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}
