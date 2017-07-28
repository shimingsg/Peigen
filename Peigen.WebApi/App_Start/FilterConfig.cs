using Newtonsoft.Json;
using Peigen.Common;
using Peigen.WebApi.Common.IOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Peigen.WebApi.App_Start
{
    public class FilterConfig
    {
        /// <summary>
        /// 过滤器注册
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(HttpFilterCollection filters)
        {
            filters.Add(new ActionFilter());
            filters.Add(new ExceptionFilter());           
        }
    }
    /// <summary>
    /// 调用action时过滤器
    /// </summary>
    public class ActionFilter: ActionFilterAttribute
    {
        /// <summary>
        /// 调用之后发生 可改变返回信息
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            var content = context.Response?.Content as ObjectContent;
            if (context.Exception != null)
            {
                var resultBox = new BaseModelRsp(ModuleCodeEnum.Sys_Framework, 3, context.Exception.Message);
                content.Value = resultBox;
            };
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

    /// <summary>
    /// 错误处理过滤器
    /// </summary>
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var content = context.Response?.Content as ObjectContent;
            var resultBox = new BaseModelRsp(ModuleCodeEnum.Sys_Framework, 3, context.Exception.Message);
            content.Value = resultBox;
            base.OnException(context);
        }
    }
}