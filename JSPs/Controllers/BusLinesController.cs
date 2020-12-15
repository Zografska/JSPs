using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JSPs.Models;

namespace JSPs.Controllers
{
    public class BusLinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BusLines
        public ActionResult Index()
        {
            return View(db.BusLines.ToList());
        }

        // GET: BusLines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusLine busLine = db.BusLines.Find(id);
            if (busLine == null)
            {
                return HttpNotFound();
            }
            return View(busLine);
        }

        // GET: BusLines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] BusLine busLine)
        {
            if (ModelState.IsValid)
            {
                db.BusLines.Add(busLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(busLine);
        }

        // GET: BusLines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusLine busLine = db.BusLines.Find(id);
            if (busLine == null)
            {
                return HttpNotFound();
            }
            return View(busLine);
        }

        // POST: BusLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] BusLine busLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(busLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(busLine);
        }

        // GET: BusLines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusLine busLine = db.BusLines.Find(id);
            if (busLine == null)
            {
                return HttpNotFound();
            }
            return View(busLine);
        }

        // POST: BusLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusLine busLine = db.BusLines.Find(id);
            db.BusLines.Remove(busLine);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SeeBuses(int id)
        {
            List<Bus> buses = db.Buses.ToList();
            string LineName = db.BusLines.Find(id).Name;
            IEnumerable toShow = buses.Where(bus => bus.BusLine == LineName);

            List<int> availableSeats = new List<int>();
            List<bool> dateAvailable = new List<bool>();
            foreach(Bus b in buses)
            {
                IEnumerable tickets = db.Tickets.Where(ticket => ticket.Bus.ID == b.ID && ticket.DateOfReservation == DateTime.Today);
                int count = 0;
                foreach (var x in tickets)
                {
                    count += 1;
                }
                availableSeats.Add(b.Capacity - count);

                int hour = DateTime.Now.Hour;
                bool check = false;
                String startTime = b.StartTime;
                if (hour < Int32.Parse(startTime.Substring(0,2)))
                    check= true;
                dateAvailable.Add(check);
            }

            ViewBag.availableSeats = availableSeats;
            ViewBag.dateAvailable = dateAvailable;
            
            return View(toShow);
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
