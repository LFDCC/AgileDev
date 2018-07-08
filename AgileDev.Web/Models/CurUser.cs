using AgileDev.Common;
using AgileDev.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace AgileDev.Web.Models
{
    public class CurUser
    {
        public static T_User User
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];//获取cookie 
                    FormsAuthenticationTicket Ticket = FormsAuthentication.Decrypt(authCookie.Value);//解密 
                    return Ticket.UserData.ToObject<T_User>();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}