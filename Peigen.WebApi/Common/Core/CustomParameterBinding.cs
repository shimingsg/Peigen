using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Peigen.WebApi
{
    public class CustomParameterBinding
    {
       
        public static HttpParameterBinding GetCustomParameterBinding(HttpParameterDescriptor descriptor)
        {
            if (descriptor.ParameterType == typeof(IPrincipal))
            {
                return new PrincipalParameterBinding(descriptor);
            }
            //接受类型 目前未定义
            //else if (descriptor.ParameterType == typeof(Areas.Management.Controllers.WeiXinController.user))
            //{
            //    return new FromUriOrBodyParameterBinding(descriptor);
            //}
            else if (descriptor.ParameterType == typeof(string)
                || descriptor.ParameterType == typeof(int)
                || descriptor.ParameterType == typeof(bool)                
                )
            {
                return new MultipleParameterFromBodyParameterBinding(descriptor);
            }

            // any other types, let the default parameter binding handle
            return null;
        }
    }
}