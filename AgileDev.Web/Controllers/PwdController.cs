using AgileDev.Web.Filter;
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