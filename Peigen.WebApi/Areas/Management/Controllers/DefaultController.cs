using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Peigen.WebApi.Areas.Management.Controllers
{
    public class DefaultController : ApiController
    {
        public string GetSomething()
        {
            return "你很棒";
        }
    }
}
