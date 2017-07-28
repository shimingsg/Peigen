using Peigen.Common;
using Peigen.Service.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peigen.Service
{
    /// <summary>
    /// Code关联具体错误信息的匹配类
    /// </summary>
    public static class ErrorMsgHelper
    {
        /// <summary>
        /// 根据Code 获取具体的错误信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns>具体的错误信息</returns>
        public static string GetMessage(string code)
        {
            string msg = string.Empty;
            if (code != ModuleCodeHelper.Success)
            {
                msg = CodeMessage.ResourceManager.GetString("C" + code);
            }

            return msg;
        }
    }
}
