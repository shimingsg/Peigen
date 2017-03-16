using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Dynamic;

namespace Peigen.WebApi.Areas.Management.Controllers
{
    public class TestController : ApiController
    {


        [HttpPost]
        public object SaveData(dynamic obj)
        {
            var strName = Convert.ToString(obj.NAME);
            return strName;
        }
    }
}
