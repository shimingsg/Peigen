using Peigen.Common;
using Peigen.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Peigen.WebApi.Common.IOModel
{
    public class BaseModelRsp
    {
        private string _resultNo;
        private MethodResultBase methodResultBase;

        public string ResultNo
        {
            get { return _resultNo; }
            set
            {
                _resultNo = value;
                ResultRemark = ErrorMsgHelper.GetMessage(value);
            }
        }
        /// <summary>
        /// 请求状态文本说明
        /// </summary>
        public string ResultRemark { get; set; }

        public BaseModelRsp() : this(new MethodResultBase())
        {

        }

        public BaseModelRsp(MethodResultBase methodResultBase)
        {
            ResultNo = methodResultBase.ResultNo;
        }
        /// <summary>
        /// 接口返回基类
        /// </summary>
        /// <param name="module"> 模块</param>
        /// <param name="status"></param>
        /// <param name="resultRemark"></param>
        public BaseModelRsp(ModuleCodeEnum module, int status, string resultRemark = "")
        {
            ResultNo = ((int)module).ToString("0000") + status.ToString("0000");

            if (!string.IsNullOrWhiteSpace(resultRemark))
            {
                ResultRemark = resultRemark;
            }
        }

        public virtual string ToJson()
        {
            return JsonHelper.Serialize(this);
        }

        public override string ToString()
        {
            return ToJson();
        }
    }
}