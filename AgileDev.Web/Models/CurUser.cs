using AgileDev.Entity;
using AgileDev.Utiliy;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Web;

namespace AgileDev.Web.Models
{
    public class CurUser
    {
        public static T_User User
        {
            get
            {
                ClaimsIdentity identity = HttpContext.Current.User.Identity as ClaimsIdentity;
                T_User user = identity.Name.ToObject<T_User>();
                var role=identity.FindFirstValue(ClaimTypes.Role);
                var uid = identity.GetUserId();
                return user;
            }
        }
    }
}