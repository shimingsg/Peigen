using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peigen.WebApi.Common.IOModel
{
    public class PagingReq: BaseModelReq
    {
        /// <summary>
        /// 当前页索引
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { get; set; }
    }
}