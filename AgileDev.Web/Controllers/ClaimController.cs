using AgileDev.Web.Filter;
using System.Web.Mvc;

namespace AgileDev.Web.Controllers
{
    [MvcAuth(Roles = "admin")]
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