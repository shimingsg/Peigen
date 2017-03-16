using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ValueProviders;

namespace Peigen.WebApi
{
    public class APIValueProviderFactory : ValueProviderFactory
    {
        public readonly string ReqKey = "reqJson";
        public override IValueProvider GetValueProvider(HttpActionContext actionContext)
        {
            throw new NotImplementedException();
        }
    }
}