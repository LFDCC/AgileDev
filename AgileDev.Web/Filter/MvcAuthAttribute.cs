using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AgileDev.Web.Filter
{
    public class MvcAuthAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool flag = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);
            if (!flag)
            {
                ClaimsPrincipal principal = filterContext.HttpContext.User as ClaimsPrincipal;
                if (principal.Identity.IsAuthenticated)
                {
                    if (!string.IsNullOrWhiteSpace(Roles) && !Roles.Split(',').Any(t => principal.IsInRole(t)))
                    {
                        filterContext.Result = new RedirectResult("/UnAuthorized/Index");
                    }
                    else
                    {
                        base.OnAuthorization(filterContext);
                    }
                }
                else
                {
                    base.OnAuthorization(filterContext);
                }
            }
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext);
        }
        //
        // 摘要:
        //     处理未能授权的 HTTP 请求。
        //
        // 参数:
        //   filterContext:
        //     封装有关使用 System.Web.Mvc.AuthorizeAttribute 的信息。filterContext 对象包括控制器、HTTP 上下文、请求上下文、操作结果和路由数据。
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}