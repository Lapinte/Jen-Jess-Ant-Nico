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

namespace BoVoyageJJAN.Areas.BackOffice.Controllers
{
    public class ReservationsController : BaseBoController
    {
        

        // GET: BackOffice/Reservations
        public ActionResult Index()
        {
            var reservations = db.Reservations.Include(x=>x.Trip.Destination).Include(x=>x.Customer);
            return View(reservations.ToList());
        }

        // GET: BackOffice/Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Include(x => x.Trip.Destination).Include(x => x.Customer).SingleOrDefault(x=>x.ID == id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: BackOffice/Reservations/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Mail");
            ViewBag.TripID = new SelectList(db.Trips, "ID", "ID");
            return View();
        }

        // POST: BackOffice/Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CreditCardNumber,TotalPrice,Insurance,ParticipantNumber,ParticipantUnderTwelveNumber,CreatedAt,CustomerID,TripID")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Mail", reservation.CustomerID);
            ViewBag.TripID = new SelectList(db.Trips, "ID", "ID", reservation.TripID);
            return View(reservation);
        }

        // GET: BackOffice/Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Mail", reservation.CustomerID);
            ViewBag.TripID = new SelectList(db.Trips, "ID", "ID", reservation.TripID);
            return View(reservation);
        }

        // POST: BackOffice/Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CreditCardNumber,TotalPrice,Insurance,ParticipantNumber,ParticipantUnderTwelveNumber,CreatedAt,CustomerID,TripID")] Reservation reservation)
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

        // GET: BackOffice/Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: BackOffice/Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            reservation.Statut = 2;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddParticipant(Participant participant)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(participant).State = EntityState.Modified;
                db.Participants.Add(participant);
                db.SaveChanges();
                
                return RedirectToAction("Edit", new { id = participant.ReservationID });
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        }

        public ActionResult DeleteParticipant(int id)
        {

            Participant person = db.Participants.Find(id);
            db.Participants.Remove(person);
            db.SaveChanges();

            return RedirectToAction("Edit", new { id = person.ReservationID });
        }

        public ActionResult Confirm(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            reservation.Statut = 3;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
