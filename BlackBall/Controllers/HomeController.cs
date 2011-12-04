using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackBall.Models;
using System.Net.Mail;

namespace BlackBall.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Finance");
            }

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            var model = new ContactViewModel();
            model.RenderTime = DateTime.Now.ToUniversalTime();
            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (DateTime.Now.ToUniversalTime() - model.RenderTime < TimeSpan.FromSeconds(3))
            {
                return View(model);
            }

            try
            {
                var mailer = new Mailer();
                mailer.SendMail(model.SendersName, model.SendersEmailAddress, "240 Hours", "info@240hours.com", "Message From Website", model.Body);
            }
            catch (SmtpException)
            {
                return View("ContactFailure");
            }

            return View("ContactSuccess");
        }
                    }
}
