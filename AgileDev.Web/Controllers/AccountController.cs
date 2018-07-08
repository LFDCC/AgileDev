using AgileDev.Common;
using AgileDev.IBLL;
using AgileDev.Model;
using AgileDev.Utils.Encrypt;
using AgileDev.Web.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace AgileDev.Web.Controllers
{
    public class AccountController : Controller
    {
        IBaseBLL _baseBLL;

        public AccountController(IBaseBLL baseBLL)
        {
            _baseBLL = baseBLL;
        }

        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {
            //using (TransactionScope scope = new TransactionScope())
            //{
            //    T_User user = new T_User
            //    {
            //        CreateTime = DateTime.Now,
            //        Password = MD5.Encrypt("000000").ToUpper(),
            //        RealName = "张三",
            //        UserName = "zhangsan"
            //    };
            //    _baseBLL.Add(user);

            //    _baseBLL.Save();

            //    _baseBLL.Add(new T_User
            //    {
            //        CreateTime = DateTime.Now,
            //        Password = MD5.Encrypt("000000").ToUpper()
            //    });

            //    _baseBLL.Save();

            //    scope.Complete();
            //}

            //var user = _baseBLL.SingleOrDefault<T_User>(u => u.UserId == 1);
            //user.RealName = "炒鸡管理员1";

            //_baseBLL.Save();

            //_baseBLL.Update<T_User>(u0 => u0.UserId == 1, u1 => new T_User { RealName = "炒鸡管理员1" });

            Expression<Func<T_User, bool>> where = u => true;
            where = where.And(u => u.UserId == 1);
            where = where.And(u => u.RealName == "炒鸡管理员1");
            where = where.Or(u => u.RealName == "炒鸡管理员1");

            var user = _baseBLL.List(where).ToList();

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