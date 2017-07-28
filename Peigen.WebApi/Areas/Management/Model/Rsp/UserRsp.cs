using Peigen.Common;
using Peigen.WebApi.Common.IOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peigen.WebApi.Areas.Management.Model.Rsp
{
    public class UserRsp: BaseModelRsp
    {
        public UserRsp() { }
        public UserRsp(MethodResultBase methodResultBase) : base(methodResultBase)
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}