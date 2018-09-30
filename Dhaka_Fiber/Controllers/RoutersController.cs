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
    public class RoutersController : Controller
    {
        private Dhaka_FiberDbContext db = new Dhaka_FiberDbContext();

        // GET: Routers
        public ActionResult Index()
        {
            return View(db.Routers.ToList());
        }

        // GET: Routers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Router router = db.Routers.Find(id);
            if (router == null)
            {
                return HttpNotFound();
            }
            return View(router);
        }

        // GET: Routers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Routers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IP,Port,Username,Password,Remarks")] Router router)
        {
            if (ModelState.IsValid)
            {
                db.Routers.Add(router);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(router);
        }

        // GET: Routers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Router router = db.Routers.Find(id);
            if (router == null)
            {
                return HttpNotFound();
            }
            return View(router);
        }

        // POST: Routers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IP,Port,Username,Password,Remarks")] Router router)
        {
            if (ModelState.IsValid)
            {
                db.Entry(router).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(router);
        }

        // GET: Routers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Router router = db.Routers.Find(id);
            if (router == null)
            {
                return HttpNotFound();
            }
            return View(router);
        }

        // POST: Routers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Router router = db.Routers.Find(id);
            db.Routers.Remove(router);
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
