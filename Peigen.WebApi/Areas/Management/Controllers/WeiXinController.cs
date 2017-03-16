using Newtonsoft.Json.Linq;
using Peigen.Domain.Entities;
using Peigen.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        [HttpPost]
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

        public PublicNumberEntity Add(int id)
        {
            return weixinService.Add(id);
        }

        [HttpPost]
        public void AddModel(user value)
        {
            var req = value.ToString();
        }

        public class user
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        [HttpPost]
        public void NewMethod()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string url = "http://api.gen.com/api/WeiXin/AddModel";

            var json = "{ \"Id\": \"10\",\"Name\": \"peigen\" }";
            var jObject = JObject.Parse(json);
            var response = client.PostAsJsonAsync(url, jObject).Result;

        }

        [HttpPost]
        public HttpResponseMessage PostMultipleParametersFromBody(string firstname, string lastname, int id)
        {
            return Request.CreateResponse(System.Net.HttpStatusCode.Accepted,
                String.Format("{2}BindCustomCoPostMultipleParametersFromBodymplexType FristName = {0}, LastName = {1}.", firstname, lastname, id));
        }
    }
}