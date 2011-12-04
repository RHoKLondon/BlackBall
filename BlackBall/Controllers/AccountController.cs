using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BlackBall.Models;

namespace BlackBall.Controllers
{
    public class AccountController : Controller
    {
        private BlackBallDatabase db = new BlackBallDatabase();

        public ActionResult Register()
        {
            var model = new RegistrationViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegistrationViewModel model, FormCollection formData)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                User u = model.ToUser();
                db.Users.Add(u);
                db.SaveChanges();

                FormsAuthentication.SetAuthCookie(u.EmailAddress, true);
                return RedirectToAction("Dashboard", "Finance");
            }
            catch
            {
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult LogIn(string emailAddress, string password, FormCollection formData)
        {
            try
            {
                if (db.Users.Any(x => x.EmailAddress == emailAddress && x.Password == password))
                {
                    FormsAuthentication.SetAuthCookie(emailAddress, true);
                    return RedirectToAction("Dashboard", "Finance");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
