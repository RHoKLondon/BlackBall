using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlackBall.Controllers
{
    public class InflowController : Controller
    {
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(FormCollection formData)
        {
            return View();
        }
    }
}
