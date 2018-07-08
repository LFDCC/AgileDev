using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgileDev.Web.Controllers
{
    public class ClaimController : Controller
    {
        // GET: Claim
        public ActionResult Index()
        {
            ViewBag.title = "理赔金到账名单";
            return View();
        }
    }
}