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
            List<Ticket> tickets = new List<Ticket>();
            tickets = db.Tickets.ToList();
            //Sprecuvame lazy loading
            foreach (Ticket ticket in tickets)
            {
                ticket.Bus = db.Buses.Where(x => x.ID == ticket.ChosenBusId).ToList()[0];
                ticket.EndDestination = (BusStop)db.BusStops.Where(x => x.ID == ticket.EndId).ToList()[0];
                ticket.StartDestination = (BusStop)db.BusStops.Where(x => x.ID == ticket.StartId).ToList()[0];
            }
            return View(tickets);
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
            //Vleguva so stiskanje na kopceto Rezerviraj
            Bus b = db.Buses.Find(id);
            ViewBag.busLine = b.BusLine;

            CreateTicketModel model = new CreateTicketModel();

            List<Bus> allBuses = db.Buses.ToList();
            List<int> ints = new List<int>();


            foreach (Bus bus in allBuses)
            {
                if (bus.BusLine.Equals(b.BusLine))
                {
                    ints.Add(b.ID);
                }
            }

            List<BusStop> busStops = db.BusStops.Where(x => x.Buses.Any(r => ints.Contains(r.ID))).ToList();

            model.BusId = id;
            model.StartBusStops = busStops;
            model.EndBusStops = busStops;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDaily([Bind(Include = "Date,BusId,StartBusStopId,EndBusStopId")] CreateTicketModel model)
        {

            Ticket ticket = new Ticket();
            ticket.Bus = db.Buses.Find(model.BusId);
            ticket.ChosenBusId = model.BusId;
            ticket.StartDestination = db.BusStops.Find(model.StartBusStopId);
            ticket.StartId = model.StartBusStopId;
            ticket.EndDestination = db.BusStops.Find(model.EndBusStopId);
            ticket.EndId = model.EndBusStopId;
            ticket.DateOfReservation = DateTime.Today;
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                user.TicketList.Add(ticket);

                db.SaveChanges();
                return RedirectToAction("Index","Manage");
            }

            return View(ticket);
        }
        // GET: Tickets/Create
        public ActionResult Create()
        {
            List<BusLine> busLines = db.BusLines.ToList();
            List<BusStop> busStops = db.BusStops.ToList();
            CreateTicketModel model = new CreateTicketModel();

            model.BusLines = busLines;
            model.StartBusStops = busStops;
            model.EndBusStops = busStops;
            return View("CreateTicket1", model);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Date,BusLineId")] CreateTicketModel model)
        {
            CreateTicketModel m = new CreateTicketModel();

            m.BusLineId = model.BusLineId;
            m.LineName = db.BusLines.Find(m.BusLineId).Name;

            m.Date = model.Date;

            List<Bus> allBuses = db.Buses.ToList();
            List<int> ints = new List<int>();


            foreach (Bus b in allBuses)
            {
                if (b.BusLine.Equals(m.LineName))
                {
                    m.Buses.Add(b);
                    ints.Add(b.ID);
                }
            }

            List<BusStop> busStops = db.BusStops.Where(x => x.Buses.Any(r => ints.Contains(r.ID))).ToList();
            m.EndBusStops = busStops;
            m.StartBusStops = busStops;
            return View("CreateTicket2", m);
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

        [HttpPost]
        public ActionResult Confirm([Bind(Include = "Date,BusId,StartBusStopId,EndBusStopId,BusLineId")] CreateTicketModel model)
        {
            if(model.Date==DateTime.Now.Date)
            {
                int hour = DateTime.Now.Hour;
                bool check = false;
                DateTime startTime = db.Buses.Find(model.BusId).StartTime;
                if (hour > startTime.Hour)
                    return View("InvalidTicket");
            }
           

            model.LineName = db.BusLines.Find(model.BusLineId).Name;
            model.Bus = db.Buses.Find(model.BusId);
            model.StartName = db.BusStops.Find(model.StartBusStopId).Name;
            model.EndName = db.BusStops.Find(model.EndBusStopId).Name;
            return View(model);
        }
        [HttpPost]
        public ActionResult TicketConfirmed([Bind(Include = "Date,BusId,StartBusStopId,EndBusStopId,BusLineId")] CreateTicketModel model)
        {

            //Zogra
            //Ova ti e kodot za kreiranje na tiket !!! SHTO PRETHODNO BESHE VO CREATE
            Ticket ticket = new Ticket();
            ticket.Bus = db.Buses.Find(model.BusId);
            ticket.ChosenBusId = model.BusId;
            ticket.StartDestination = db.BusStops.Find(model.StartBusStopId);
            ticket.StartId = model.StartBusStopId;
            ticket.EndDestination = db.BusStops.Find(model.EndBusStopId);
            ticket.EndId = model.EndBusStopId;
            ticket.DateOfReservation = DateTime.Today;
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            ticket.User = user;

            if (user == null)
                return View("notLogedIn");

            db.Tickets.Add(ticket);
            user.TicketList.Add(ticket);
            db.SaveChanges();


            return RedirectToAction("Index", "Manage");
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
