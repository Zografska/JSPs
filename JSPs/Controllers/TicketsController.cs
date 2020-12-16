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
                    return View("notLogedIn");

                db.Users.Find(userId).TicketList.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(ticket);
        }
        // GET: Tickets/Create
        public ActionResult Create()
        {
            List<BusLine> busLines = db.BusLines.ToList();
            List<String> busLineNames = new List<string>();
            foreach (var b in busLines)
            {
                busLineNames.Add(b.Name);
            }
            ViewBag.busLineNames = busLineNames;
            //otkako kje se selektira linija treba avtobusite da gi izlista za denta
            //otkako kje se selektira avtobus treba da se izlistaat postojkite
            //ovde da se naprai za selektiraniot avtobus da se prikazhuvaat postojkite
            ViewBag.busStops = db.BusStops.ToList();
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DateOfReservation")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);

                var userId = User.Identity.GetUserId();
                db.Users.Find(userId).TicketList.Add(ticket);

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
