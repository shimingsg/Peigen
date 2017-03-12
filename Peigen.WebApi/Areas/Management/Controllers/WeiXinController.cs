using Peigen.Domain.Entities;
using Peigen.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Peigen.WebApi.Areas.Management.Controllers
{    
    public class WeiXinController : ApiController
    {
        private IWeiXinService weixinService;
        //public WeiXinController(IWeiXinService _weixinService)
        //{
        //    weixinService = _weixinService;
        //}
        
        public string GetSomething()
        {
            return "你很棒";
        }
       
        public PublicNumberEntity GetById(int id)
        {
            return weixinService.GetById(id);
        }
    }
}