using System;
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
    public class BusStopsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BusStops
        public ActionResult Index()
        {
            return View(db.BusStops.ToList());
        }

        // GET: Modal
        public ActionResult PickEndDestination()
        {
            return PartialView();
        }

        // GET: BusStops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            BusStop busStop = db.BusStops.Find(id);
            busStop.Buses = db.Buses.Where(x => x.BusStops.Any(y => y.ID == id)).ToList();
                //Stops.Where(x => x.Buses.Any(y => y.ID == id)).ToList();
            if (busStop == null)
            {
                return HttpNotFound();
            }
            return View(busStop);
        }

        // GET: BusStops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusStops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] BusStop busStop)
        {
            if (ModelState.IsValid)
            {
                db.BusStops.Add(busStop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(busStop);
        }

        // GET: BusStops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusStop busStop = db.BusStops.Find(id);
            if (busStop == null)
            {
                return HttpNotFound();
            }
            return View(busStop);
        }

        // POST: BusStops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] BusStop busStop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(busStop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(busStop);
        }

        // GET: BusStops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusStop busStop = db.BusStops.Find(id);
            if (busStop == null)
            {
                return HttpNotFound();
            }
            return View(busStop);
        }

        // POST: BusStops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusStop busStop = db.BusStops.Find(id);
            db.BusStops.Remove(busStop);
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
