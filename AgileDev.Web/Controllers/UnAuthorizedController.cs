using AgileDev.Web.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgileDev.Web.Controllers
{
    public class UnAuthorizedController : Controller
    {
        // GET: UnAuthorized
        public ActionResult Index()
        {
            return View();
        }
    }
}