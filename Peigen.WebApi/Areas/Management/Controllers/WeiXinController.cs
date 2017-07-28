using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Peigen.Common;
using Peigen.Domain.Entities;
using Peigen.Service;
using Peigen.WebApi.Areas.Management.Model.Rsp;
using Peigen.WebApi.Common.IOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public WeiXinController(IWeiXinService _weixinService, IMemberService _memberService)
        {
            weixinService = _weixinService;
            memberService = _memberService;
        }

        public string GetUserName()
        {
            return memberService.GetUserName();
        }

        [HttpPost]
        public string GetSomething()
        {
            //return "你很棒";
            //var a = 16;
            //var b = 5;
            //var c = Math.Ceiling((decimal)a / b);
            int[] numbers = { };
            int count = numbers.Where(x => x == 1).Count();

            int[] first3Numbers = numbers.Take(30).ToArray();
            MemberFactory.GetFactory().GetUserName();
            return "";
        }

        public PublicNumberEntity GetById(int id)
        {
            return weixinService.GetById(id);
        }

        public HttpResponseMessage GetList(int type)
        {
            return Request.CreateResponse(System.Net.HttpStatusCode.Accepted, JsonConvert.SerializeObject(weixinService.GetMany(type)));
        }
        [HttpPost]
        public PublicNumberEntity Add(int id)
        {
            return weixinService.Add(id);
        }

        [HttpPost]
        public void AddModel(user value)
        {
            var req = value.ToString();
        }

        [HttpPost]
        public string GetString(string ss)
        {
            return ss;
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
            string url = "http://api.gen.com/api/WeiXin/DoThings";

            var json = "{ \"Id\": \"10\",\"Name\": \"\" }";
            var jObject = JObject.Parse(json);
            var response = client.PostAsJsonAsync(url, jObject).Result;

        }

        [HttpPost]
        public HttpResponseMessage PostMultipleParametersFromBody(string firstname, string lastname, int id, bool a)
        {
            return Request.CreateResponse(System.Net.HttpStatusCode.Accepted,
                String.Format("{2}BindCustomCoPostMultipleParametersFromBodymplexType FristName = {0}, LastName = {1}.", firstname, lastname, id));
        }
        [HttpPost]
        public user ReturnUser()
        {
            var user = new user();
            user.Id = 1;
            user.Name = "peigen";
            return user;
        }

        

        [HttpPost]
        public HttpResponseMessage DoThings(user obj)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "11111");

        }

        [HttpPost]
        public UserRsp GetUserRsp()
        {
            var result = new UserRsp();
            result.Id = 1;
            result.Name = "peigen";
            return new UserRsp(new MethodResultFull<UserRsp>(ModuleCodeEnum.Core_Area, 1));
            //return result;
        }

        [HttpPost]
        public PagingRsp<UserRsp> GetUserRspList()
        {            
            var list = new List<user>();
            list.Add(new user
            {
                Id = 1,
                Name = "培根"
            });
            var data = new MethodResultFull<List<user>>();
            data.Content = list;
            var result = new PagingRsp<UserRsp>(data);
            result.Data = data.Content.Select(x => new UserRsp
            {
                Id=x.Id,
                Name=x.Name
            }).ToList();
            return result;
        }
    }
}