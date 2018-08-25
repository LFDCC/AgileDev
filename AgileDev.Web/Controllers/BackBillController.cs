using AgileDev.Web.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgileDev.Web.Controllers
{
    [MvcAuth(Roles = "admin,custom")]
    public class BackBillController : Controller
    {
        // GET: BackBill
        public ActionResult Index()
        {
            ViewBag.title = "保单退回名单";
            return View();
        }
    }
}