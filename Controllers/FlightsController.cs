using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class FlightsController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Flights
        public ActionResult Index()
        {
            var flights = db.Flights.Include(f => f.User);
            return View(flights.ToList());
        }

        // GET: Flights/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // GET: Flights/Create
        public ActionResult Create()
        {
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "Password");
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Flight_Number,User_ID,Arrival_Time,Arrival_Date,Departure_Date,Departure_Time,Destination_,Number_of_passengers")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Flights.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "Password", flight.User_ID);
            return View(flight);
        }

        // GET: Flights/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "Password", flight.User_ID);
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Flight_Number,User_ID,Arrival_Time,Arrival_Date,Departure_Date,Departure_Time,Destination_,Number_of_passengers")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "Password", flight.User_ID);
            return View(flight);
        }

        // GET: Flights/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Flight flight = db.Flights.Find(id);
            db.Flights.Remove(flight);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookFlight(ViewModels.BookFlightViewModel model)
        {
            if (!db.Flights.Any(x => x.Flight_Number == model.Flight_Number))
            {
                Flight Flightrecord = new Flight();
                Flightrecord.Flight_Number = model.Flight_Number;
                Flightrecord.User_ID = model.User_ID;
                Flightrecord.Arrival_Date = model.Arrival_Date;
                Flightrecord.Arrival_Time = model.Arrival_Time;
                Flightrecord.Departure_Date = model.Departure_Date;
                Flightrecord.Departure_Time = model.Departure_Time;
                db.Flights.Add(Flightrecord);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else if (db.Flights.Any(x => x.Flight_Number == model.Flight_Number))
            {
                ModelState.AddModelError("Flight_Number", "Flight already booked");
            }


            return View(model);
        }




        public ActionResult BookFlight()
        {
            return View();
        }


    }
}

      