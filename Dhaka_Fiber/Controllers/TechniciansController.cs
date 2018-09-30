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
    public class TechniciansController : Controller
    {
        private Dhaka_FiberDbContext db = new Dhaka_FiberDbContext();

        // GET: Technicians
        public ActionResult Index()
        {
            var technicians = db.Technicians.Include(t => t.Technician_Experties).Include(t => t.User_Role);
            return View(technicians.ToList());
        }

        // GET: Technicians/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technician technician = db.Technicians.Find(id);
            if (technician == null)
            {
                return HttpNotFound();
            }
            return View(technician);
        }

        // GET: Technicians/Create
        public ActionResult Create()
        {
            ViewBag.Experties = new SelectList(db.Technician_Experties, "Id", "Tech_exp");
            ViewBag.Role = new SelectList(db.User_Role, "Id", "Name");
            return View();
        }

        // POST: Technicians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Role,Login_Name,Password,Full_Name,NID,Email,Mobile,Experties,Address")] Technician technician)
        {
            if (ModelState.IsValid)
            {
                db.Technicians.Add(technician);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Experties = new SelectList(db.Technician_Experties, "Id", "Tech_exp", technician.Experties);
            ViewBag.Role = new SelectList(db.User_Role, "Id", "Name", technician.Role);
            return View(technician);
        }

        // GET: Technicians/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technician technician = db.Technicians.Find(id);
            if (technician == null)
            {
                return HttpNotFound();
            }
            ViewBag.Experties = new SelectList(db.Technician_Experties, "Id", "Tech_exp", technician.Experties);
            ViewBag.Role = new SelectList(db.User_Role, "Id", "Name", technician.Role);
            return View(technician);
        }

        // POST: Technicians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Role,Login_Name,Password,Full_Name,NID,Email,Mobile,Experties,Address")] Technician technician)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technician).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Experties = new SelectList(db.Technician_Experties, "Id", "Tech_exp", technician.Experties);
            ViewBag.Role = new SelectList(db.User_Role, "Id", "Name", technician.Role);
            return View(technician);
        }

        // GET: Technicians/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technician technician = db.Technicians.Find(id);
            if (technician == null)
            {
                return HttpNotFound();
            }
            return View(technician);
        }

        // POST: Technicians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Technician technician = db.Technicians.Find(id);
            db.Technicians.Remove(technician);
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
