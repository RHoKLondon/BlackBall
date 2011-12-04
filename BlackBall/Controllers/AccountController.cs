using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackBall.Models;

namespace BlackBall.Controllers
{
    public class AccountController : Controller
    {
        private BlackBallDatabase db = new BlackBallDatabase();

        public ActionResult Register()
        {
            var model = new User();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(User u, FormCollection formData)
        {
            if (!ModelState.IsValid)
            {
                return View(u);
            }

            try
            {
                db.Users.Add(u);
                db.SaveChanges();

                // todo
            }
            catch
            {
                return View(u);
            }

            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
