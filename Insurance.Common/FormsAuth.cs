using System;
using System.Web;
using System.Web.Security;

namespace Insurance.Common
{
    /// <summary>
    /// form验证
    /// </summary>
    public class FormsAuth
    {

        public static void SignIn<T>(string id, T t) where T : class, new()
        {
            //创建一个FormsAuthenticationTicket，它包含登录名以及额外的用户数据。
            var ticket = new FormsAuthenticationTicket(2,
                id, DateTime.Now, DateTime.Now.AddDays(1), true, t.ToJson());
            //加密Ticket，变成一个加密的字符串。
            var cookieValue = FormsAuthentication.Encrypt(ticket);

            //根据加密结果创建登录Cookie
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieValue)
            {
                HttpOnly = true,
                Secure = FormsAuthentication.RequireSSL,
                Domain = FormsAuthentication.CookieDomain,
                Path = FormsAuthentication.FormsCookiePath
            };
            var context = HttpContext.Current;

            //写登录Cookie
            context.Response.Cookies.Remove(cookie.Name);
            context.Response.Cookies.Add(cookie);
        }

        public static void SignOut()
        {
            FormsAuthentication.SignOut();
        }

    }
}
