using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewVidly.Controllers
{
    public class RentalController : Controller
    {
        public ActionResult New()
        {
            return View();
        }
    }
}