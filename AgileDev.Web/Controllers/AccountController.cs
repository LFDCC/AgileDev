using AgileDev.Application.Enum;
using AgileDev.Application.Record;
using AgileDev.Application.User;
using AgileDev.Entity;
using AgileDev.Utiliy;
using AgileDev.Utiliy.Encrypt;
using AgileDev.Utiliy.Now;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AgileDev.Web.Controllers
{
    public class AccountController : Controller
    {
        private IRecordAppServices _recordServices;
        private IUserAppServices _userServices;

        public AccountController(IUserAppServices userServices, IRecordAppServices recordServices)
        {
            _userServices = userServices;
            _recordServices = recordServices;            
        }

        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {
#if true
            //如果使用多个对象可以使用IUnitOfWork进行事务提交，同一对象下的Save本身就是事务的
#if false
            T_User user0 = new T_User
                {
                    CreateTime = DateTime.Now,
                    Password = MD5.Encrypt("000000").ToUpper(),
                    RealName = "张三",
                    UserName = "zhangsan"
                };

                _userServices.Add(user0);

                T_User user1 = new T_User
                {
                    CreateTime = DateTime.Now,
                    Password = MD5.Encrypt("000000").ToUpper(),
                    RealName = "张三00",
                    UserName = "张三00"
                };
                _userServices.Add(user1);

                _userServices.Save();
            }
#endif
            {
                using (IUnitOfWork unitOfWork = IocConfig.Resolve<IUnitOfWork>())
                {
                    T_User user0 = new T_User
                    {
                        CreateTime = DateTime.Now,
                        Password = MD5.Encrypt("000000").ToUpper(),
                        RealName = "张三",
                        UserName = "zhangsan"
                    };

                    _userServices.Add(user0);
                    _userServices.Save();

                    T_Record record = new T_Record

                    {
                        Remark = "test",
                        UserId = 11,
                        Title = "asdfdsf"
                    };
                    _recordServices.Add(record);
                    _recordServices.Save();
                    throw new Exception("error");

                    //提交
                    unitOfWork.Commit();
                }
            }
#endif
            //var user = _userServices.SingleOrDefault(u => u.UserId == 1);
            //user.RealName = "炒鸡管理员1";

            //_userServices.Save();

            //_userServices.Update(u0 => u0.UserId == 1, u1 => new T_User { RealName = "炒鸡管理员1" });

            Expression<Func<T_User, bool>> where = u => true;
            where = where.And(u => u.UserId == 1);
            where = where.And(u => u.RealName == "炒鸡管理员1");
            where = where.Or(u => u.RealName == "炒鸡管理员1");

            var user = _userServices.List(where).ToList();

            ViewBag.returnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, string returnUrl)
        {
            if (!Request.IsAjaxRequest())
            {
                return View();
            }
            password = MD5.Encrypt(password).ToUpper();
            T_User user = _userServices.SingleOrDefault(t => t.UserName.Equals(username));
            if (user == null)
            {
                return Json(new { status = HttpResult.fail, message = "用户名不存在！" });
            }
            else
            {
                user = _userServices.SingleOrDefault(t => t.UserName.Equals(username) && t.Password.Equals(password));
                if (user == null)
                {
                    return Json(new { status = HttpResult.fail, message = "密码错误！" });
                }
                else
                {
                    var identity = new ClaimsIdentity(new List<Claim> {
                        new Claim(ClaimTypes.Name, user.ToJson()),
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                         new Claim(ClaimTypes.Role, "admin")
                    }, DefaultAuthenticationTypes.ApplicationCookie);

                    HttpContext.GetOwinContext().Authentication.SignIn(identity);

                    return Json(new { status = HttpResult.success, jumpUrl = returnUrl ?? "/Claim/Index" });
                }
            }
        }

        public ActionResult LogOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}