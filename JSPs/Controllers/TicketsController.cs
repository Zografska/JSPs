using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;

using JSPs.Models;

namespace JSPs.Controllers
{
    public class TicketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tickets
        public ActionResult Index()
        {
            return View(db.Tickets.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);

            //Bus bus = db.Buses.Find(ticket.Bus.ID);
            
            //List<BusStop> busStops = db.BusStops.Where(x => x.Buses.Any(y => y.ID == ticket.Bus.ID)).ToList();
            //ViewBag.Test = busStops.Find(b => b.ID == ticket.StartDestination.ID);

            // ticket.EndDestination = db.BusStops.Where(x => x.Buses.Any(y => y.ID == id)).ToList()[0];
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        public ActionResult CreateDaily(int id)
        {
            Bus b = db.Buses.Find(id);
            ViewBag.bus = b;
            // ova ne znam zashto ne raboti
            IEnumerable<BusStop> stops = b.BusStops;
            ViewBag.stops = stops.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDaily([Bind(Include = "ID,DateOfReservation")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);

                var userId = User.Identity.GetUserId();
                if (db.Users.Find(userId) == null)
                    return View("notLoggedIn");

                db.Users.Find(userId).TicketList.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(ticket);
        }
        // GET: Tickets/Create
        public ActionResult Create()
        {
            List<Bus> buses = db.Buses.ToList();
          
            //otkako kje se selektira linija treba avtobusite da gi izlista za denta
            //otkako kje se selektira avtobus treba da se izlistaat postojkite
            //ovde da se naprai za selektiraniot avtobus da se prikazhuvaat postojkite
            List<BusStop> busStops = db.BusStops.ToList();
            CreateTicketModel model = new CreateTicketModel();
            model.Buses = buses;
            model.StartBusStops = busStops;
            model.EndBusStops = busStops;
            return View("CreateTicket",model);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Date,BusId,StartBusStopId,EndBusStopId")] CreateTicketModel model)
        {
            Ticket ticket = new Ticket();
            ticket.Bus = db.Buses.Find(model.BusId);
            ticket.StartDestination = db.BusStops.Find(model.StartBusStopId);
            ticket.EndDestination = db.BusStops.Find(model.EndBusStopId);
            ticket.DateOfReservation = model.Date;

            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);

               // var userId = User.Identity.GetUserId();
               // db.Users.Find(userId).TicketList.Add(ticket);

                db.SaveChanges();
                return RedirectToAction("Index");

            }


            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DateOfReservation")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
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
    }
}
