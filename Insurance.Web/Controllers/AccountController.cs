using Insurance.BLL;
using Insurance.Common;
using Insurance.IBLL;
using Insurance.Model;
using Insurance.Utils.Encrypt;
using Insurance.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace Insurance.Web.Controllers
{
    public class AccountController : Controller
    {
        IBaseBLL _baseBLL = BaseBLL.GetInstance();

        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {

            ViewBag.returnUrl = ReturnUrl;
            if (CurUser.User != null)
            {
                return RedirectToAction("Index", "Claim");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string username, string password)
        {
            if (!Request.IsAjaxRequest())
            {
                return View();
            }
            password = MD5.Encrypt(password).ToUpper();
            T_User user = _baseBLL.SingleOrDefault<T_User>(t => t.UserName.Equals(username));
            if (user == null)
            {
                return Json(new { status = HttpResult.fail, message = "用户名不存在！" });
            }
            else
            {
                user = _baseBLL.SingleOrDefault<T_User>(t => t.UserName.Equals(username) && t.Password.Equals(password));
                if (user == null)
                {
                    return Json(new { status = HttpResult.fail, message = "密码错误！" });
                }
                else
                {
                    FormsAuth.SignIn(user.UserId.ToString(), user);
                    return Json(new { status = HttpResult.success, jumpUrl = ViewBag.returnUrl ?? "/Claim/Index" });
                }

            }
        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuth.SignOut();
            return RedirectToAction("Login");
        }
    }
}