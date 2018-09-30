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
    public class PlansController : Controller
    {
        private Dhaka_FiberDbContext db = new Dhaka_FiberDbContext();

        // GET: Plans
        public ActionResult Index()
        {
            var plans = db.Plans.Include(p => p.Bandwidth_Plans).Include(p => p.IP_Pools1).Include(p => p.Router1);
            return View(plans.ToList());
        }

        // GET: Plans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plans.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // GET: Plans/Create
        public ActionResult Create()
        {
            ViewBag.Bandwidth_Name = new SelectList(db.Bandwidth_Plans, "Id", "Bandwidth_Name");
            ViewBag.IP_Pools = new SelectList(db.IP_Pools, "Id", "Pool_Name");
            ViewBag.Router = new SelectList(db.Routers, "Id", "Name");
            return View();
        }

        // POST: Plans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Plan_Name,Bandwidth_Name,Plan_Price,Plan_Validity,Plan_Validity_d_m,Connection_Type,Shared_Users,Router,IP_Pools")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Plans.Add(plan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bandwidth_Name = new SelectList(db.Bandwidth_Plans, "Id", "Bandwidth_Name", plan.Bandwidth_Name);
            ViewBag.IP_Pools = new SelectList(db.IP_Pools, "Id", "Pool_Name", plan.IP_Pools);
            ViewBag.Router = new SelectList(db.Routers, "Id", "Name", plan.Router);
            return View(plan);
        }

        // GET: Plans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plans.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bandwidth_Name = new SelectList(db.Bandwidth_Plans, "Id", "Bandwidth_Name", plan.Bandwidth_Name);
            ViewBag.IP_Pools = new SelectList(db.IP_Pools, "Id", "Pool_Name", plan.IP_Pools);
            ViewBag.Router = new SelectList(db.Routers, "Id", "Name", plan.Router);
            return View(plan);
        }

        // POST: Plans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Plan_Name,Bandwidth_Name,Plan_Price,Plan_Validity,Plan_Validity_d_m,Connection_Type,Shared_Users,Router,IP_Pools")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bandwidth_Name = new SelectList(db.Bandwidth_Plans, "Id", "Bandwidth_Name", plan.Bandwidth_Name);
            ViewBag.IP_Pools = new SelectList(db.IP_Pools, "Id", "Pool_Name", plan.IP_Pools);
            ViewBag.Router = new SelectList(db.Routers, "Id", "Name", plan.Router);
            return View(plan);
        }

        // GET: Plans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plans.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plan plan = db.Plans.Find(id);
            db.Plans.Remove(plan);
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
