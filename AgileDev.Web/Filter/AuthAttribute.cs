using AgileDev.Application.Enum;
using AgileDev.Web.Models;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AgileDev.Web.Filter
{
    /// <summary>
    /// 身份验证
    /// </summary>
    public class AuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool flag = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);
            if (!flag)
            {
                //如果存在身份信息
                if (!HttpContext.Current.User.Identity.IsAuthenticated || CurUser.User == null)
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {//ajax超时处理
                        filterContext.Result = new JsonResult() { Data = new { status = HttpResult.timeout, message = "登录超时！", redirect = FormsAuthentication.LoginUrl }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    }
                    else
                    {
                        string url = string.Format("{0}?ReturnUrl={1}", FormsAuthentication.LoginUrl, filterContext.HttpContext.Request.RawUrl);
                        filterContext.Result = new RedirectResult(url);
                    }
                }
            }
        }
    }
}