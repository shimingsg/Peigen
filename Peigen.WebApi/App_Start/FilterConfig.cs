using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Peigen.WebApi.App_Start
{
    public class FilterConfig: ActionFilterAttribute
    {
        /// <summary>
        /// 调用之后发生 可改变返回信息
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            var content = context.Response?.Content as ObjectContent;
            if (content != null)
            {
                
            }

            base.OnActionExecuted(context);
        }

        /// <summary>
        /// 调用之前发生 可记录调用信息
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
        }
    }
}