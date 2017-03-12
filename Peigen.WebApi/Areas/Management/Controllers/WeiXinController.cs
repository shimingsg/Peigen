using Peigen.Domain.Entities;
using Peigen.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Peigen.WebApi.Areas.Management.Controllers
{    
    [RoutePrefix("api/WeiXin")]
    public class WeiXinController : ApiController
    {
        private readonly IWeiXinService weixinService;
        public WeiXinController(IWeiXinService _weixinService)
        {
            weixinService = _weixinService;
        }
        [Route("GetSomething")]
        public string GetSomething()
        {
            return "你很棒";
        }
        [Route("GetById")]
        public PublicNumberEntity GetById(int id)
        {
            return weixinService.GetById(id);
        }
    }
}