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
        private IMemberService memberService;
        public WeiXinController(IWeiXinService _weixinService,IMemberService _memberService)
        {
            weixinService = _weixinService;
            memberService = _memberService;
        }

        public string GetUserName()
        {
            return memberService.GetUserName();
        }

        public string GetSomething(int a,int b)
        {
            //return "你很棒";
            //var a = 16;
            //var b = 5;
            //var c = Math.Ceiling((decimal)a / b);
            int[] numbers = { };
            int[] first3Numbers = numbers.Take(30).ToArray();
            MemberFactory.GetFactory().GetUserName();
            return "";
        }
       
        public PublicNumberEntity GetById(int id)
        {
            return weixinService.GetById(id);
        }

        public List<PublicNumberEntity> GetList(int type)
        {
            return weixinService.GetMany(type);
        }


    }
}