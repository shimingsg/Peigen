using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peigen.Common
{
    public class MethodResultBase
    {
        /// <summary>
        /// 请求状态编码，0：成功、正数：程序逻辑错误（如参数不合法、安全校验未通过等）、负数：程序未知异常（如数据库连接失败等）
        /// </summary>
        public string ResultNo { get; set; }
        public static MethodResultBase Success = new MethodResultBase();
        //隐式转换
        public static implicit operator bool(MethodResultBase result)
        {
            return result.ResultNo == ModuleCodeHelper.Success;
        }

        public MethodResultBase() : this(ModuleCodeEnum.Success, 0)
        {
        }

        public MethodResultBase(ModuleCodeEnum moduleCode, int statusCode)
        {
            ResultNo = moduleCode.GetErrorCode(statusCode);
        }

        public MethodResultBase(MethodResultBase methodReultBase)
        {
            ResultNo = methodReultBase.ResultNo;
        }

        public virtual bool IsSuccess()
        {
            return this.ResultNo == ModuleCodeHelper.Success;
        }
    }
}
