using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;
using APIService.Models;
using DataBaseDesign.Common;
using DataBaseDesign.IService;
using DataBaseDesign.Model;

namespace APIService
{
    /// <summary>
    /// 处理Api运行期间发生的异常
    /// </summary>
    public class APIExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);
            actionExecutedContext.Response = JsonHelp.GetJsonContent(500, "程序运行期间发生了未知错误");
        }
    }

    /// <summary>
    /// 处理API调用的身份验证
    /// </summary>
    public class APIAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
           // base.OnAuthorization(actionContext);
            string[] strings = actionContext.Request.RequestUri.Segments;
            string token = strings[strings.Length - 1];
            string assembly = "ApiAuthorityVerificationAssembly";
            string name = "ApiAuthorityVerificationName";
            IApiAuthorityVerificationService iaav = CreatInstanceHelp.CreatInstanceByConfigOnlyUserAssemblyName<IApiAuthorityVerificationService>(assembly, name);
            ApiAuthorityVerification aav = iaav.Where(o => o.Token.ToString() == token).FirstOrDefault();
            if (aav != null) return;
            actionContext.Response = JsonHelp.GetJsonContent(400, "未被授权！");
        }
    }

    /// <summary>
    /// 处理运行API的前后操作，晚于AuthorizeAttribute
    /// </summary>
    public class APIActionFilterAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        /// <summary>
        /// Action之前
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
        }
        /// <summary>
        /// Action之后
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }
    }

    /// <summary>
    /// 处理普通控制器运行期间的发生的异常
    /// </summary>
    public class ControllerExceptionFilterAttribute : System.Web.Mvc.HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            filterContext.Result = new RedirectResult("~/Error.html");
        }
    }
}