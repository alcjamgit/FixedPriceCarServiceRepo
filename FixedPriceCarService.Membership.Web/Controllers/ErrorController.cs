using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixedPriceCarService.Membership.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string message)
        {
            return View();
        }
        public ActionResult HttpError404(string message)
        {
           return View();
        }
        public ActionResult HttpError500(string message)
        {
            return View();
        }

    }
}