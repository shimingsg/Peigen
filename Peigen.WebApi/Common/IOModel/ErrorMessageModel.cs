using Peigen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peigen.WebApi.Common.IOModel
{
    /// <summary>
    /// 错误提示
    /// </summary>
    public class ErrorMessageModel
    {
        public ModuleCodeEnum ModuleCode { get; set; }

        public int Status { get; set; }

        public string Message { get; set; }
    }
}