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
            return View();
        }

        public ActionResult AddInflowItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInflowItem(FormCollection formData)
        {
            return View();
        }

        public ActionResult AddOutflowItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOutflowItem(FormCollection formData)
        {
            return View();
        }
    }
}
