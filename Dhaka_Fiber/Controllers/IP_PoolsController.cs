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
    public class IP_PoolsController : Controller
    {
        private Dhaka_FiberDbContext db = new Dhaka_FiberDbContext();

        // GET: IP_Pools
        public ActionResult Index()
        {
            return View(db.IP_Pools.ToList());
        }

        // GET: IP_Pools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IP_Pools iP_Pools = db.IP_Pools.Find(id);
            if (iP_Pools == null)
            {
                return HttpNotFound();
            }
            return View(iP_Pools);
        }

        // GET: IP_Pools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IP_Pools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Pool_Name,IP_Range,Router,Reamaks")] IP_Pools iP_Pools)
        {
            if (ModelState.IsValid)
            {
                db.IP_Pools.Add(iP_Pools);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iP_Pools);
        }

        // GET: IP_Pools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IP_Pools iP_Pools = db.IP_Pools.Find(id);
            if (iP_Pools == null)
            {
                return HttpNotFound();
            }
            return View(iP_Pools);
        }

        // POST: IP_Pools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Pool_Name,IP_Range,Router,Reamaks")] IP_Pools iP_Pools)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iP_Pools).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iP_Pools);
        }

        // GET: IP_Pools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IP_Pools iP_Pools = db.IP_Pools.Find(id);
            if (iP_Pools == null)
            {
                return HttpNotFound();
            }
            return View(iP_Pools);
        }

        // POST: IP_Pools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IP_Pools iP_Pools = db.IP_Pools.Find(id);
            db.IP_Pools.Remove(iP_Pools);
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
