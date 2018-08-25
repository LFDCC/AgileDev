using AgileDev.Web.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgileDev.Web.Controllers
{
    [MvcAuth]
    public class PwdController : Controller
    {
        // GET: Pwd
        public ActionResult Index()
        {
            return View();
        }
    }
}