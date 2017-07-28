using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peigen.Common
{
    public static class ModuleCodeHelper
    {
        /// <summary>
        /// 状态成功的值
        /// </summary>
        public const string Success = "00000000";
        /// <summary>
        /// 利用模块和状态码获取错误的Code
        /// </summary>
        /// <param name="this"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static string GetErrorCode(this ModuleCodeEnum @this, int statusCode)
        {
            int code = ((int)@this) * 10000 + statusCode;

            return code.ToString().PadLeft(8, '0');
        }
        
        /// <summary>
        /// 利用ErrorCode获取模块
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public static ModuleCodeEnum TryParse(string errorCode)
        {
            Tuple<ModuleCodeEnum, int> result = Parse(errorCode);
            if (result == null)
            {
                throw new ArgumentException("errorCode格式不正确，无法从中获取模块枚举！");
            }

            return result.Item1;
        }

        private static Tuple<ModuleCodeEnum, int> Parse(string errorCode)
        {
            throw new NotImplementedException();
        }
    }
}