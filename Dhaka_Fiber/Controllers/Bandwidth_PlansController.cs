using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dhaka_Fiber.Models;

namespace Dhaka_Fiber.Controllers
{
    public class Bandwidth_PlansController : Controller
    {
        private Dhaka_FiberDbContext db = new Dhaka_FiberDbContext();

        // GET: Bandwidth_Plans
        public ActionResult Index()
        {
            return View(db.Bandwidth_Plans.ToList());
        }

        // GET: Bandwidth_Plans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bandwidth_Plans bandwidth_Plans = db.Bandwidth_Plans.Find(id);
            if (bandwidth_Plans == null)
            {
                return HttpNotFound();
            }
            return View(bandwidth_Plans);
        }

        // GET: Bandwidth_Plans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bandwidth_Plans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Bandwidth_Name,Rate_Download,Rate_Upload,Remarks")] Bandwidth_Plans bandwidth_Plans)
        {
            if (ModelState.IsValid)
            {
                db.Bandwidth_Plans.Add(bandwidth_Plans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bandwidth_Plans);
        }

        // GET: Bandwidth_Plans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bandwidth_Plans bandwidth_Plans = db.Bandwidth_Plans.Find(id);
            if (bandwidth_Plans == null)
            {
                return HttpNotFound();
            }
            return View(bandwidth_Plans);
        }

        // POST: Bandwidth_Plans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Bandwidth_Name,Rate_Download,Rate_Upload,Remarks")] Bandwidth_Plans bandwidth_Plans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bandwidth_Plans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bandwidth_Plans);
        }

        // GET: Bandwidth_Plans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bandwidth_Plans bandwidth_Plans = db.Bandwidth_Plans.Find(id);
            if (bandwidth_Plans == null)
            {
                return HttpNotFound();
            }
            return View(bandwidth_Plans);
        }

        // POST: Bandwidth_Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bandwidth_Plans bandwidth_Plans = db.Bandwidth_Plans.Find(id);
            db.Bandwidth_Plans.Remove(bandwidth_Plans);
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
