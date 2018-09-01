using AgileDev.Web.Filter;
using System.Web.Mvc;

namespace AgileDev.Web.Controllers
{
    [MvcAuth]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}