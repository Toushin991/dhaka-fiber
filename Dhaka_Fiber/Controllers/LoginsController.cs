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
    public class LoginsController : Controller
    {
        private Dhaka_FiberDbContext db = new Dhaka_FiberDbContext();

        // GET: Logins
        public ActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        
        public ActionResult Login(Login objUser)
        {
            if (ModelState.IsValid)
            {

                var obj = db.Logins.Where(a => a.Username ==objUser.Username && a.Password==objUser.Password).FirstOrDefault();
                if (obj != null)
                {
                    Session["UserId"] = obj.UserId;
                  //  ViewBag.Roles = new SelectList(db.User_Role, "Id", "Name", objUser.Role);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Wrong User name or password";
               //     ViewBag.Roles = new SelectList(db.User_Role, "Id", "Name", objUser.Role);
                    return View();
                }
                
            }
            return View(objUser);
        }

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Logout()
        {
            string UserId = (string)Session["UserId"];
            Session.Abandon();
            return RedirectToAction("Login");

        }



    }
}
