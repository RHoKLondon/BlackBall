using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackBall.Models;

namespace BlackBall.Controllers
{
    [Authorize]
    public class FinanceController : Controller
    {
        private BlackBallDatabase db = new BlackBallDatabase();

        public ActionResult Dashboard()
        {
            var model = db.Users.Single(x => x.EmailAddress == this.User.Identity.Name);
            return View(model);
        }

        public ActionResult AddInflowItem()
        {
            var model = new InflowItem();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddInflowItem(InflowItem model, FormCollection formData)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var user = db.Users.Single(x => x.EmailAddress == this.User.Identity.Name);
                user.Inflow.Add(model);
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            catch
            {
                return View(model);
            }
        }

        public ActionResult AddOutflowItem()
        {
            var model = new OutflowItem();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddOutflowItem(OutflowItem model, FormCollection formData)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var user = db.Users.Single(x => x.EmailAddress == this.User.Identity.Name);
                user.Outflow.Add(model);
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            catch
            {
                return View(model);
            }
        }
    }
}
