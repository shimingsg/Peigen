using Peigen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peigen.WebApi.Common.IOModel
{
    public class PagingRsp<T> : BaseModelRsp
    {
        public PagingRsp(IEnumerable<T> data)
        {
            Data = data;
            PageIndex = 1;
            PageSize = Total = data.Count();
        }
        public PagingRsp(ModuleCodeEnum module, int status, string remark) : base(module, status, remark)
        { }

        public PagingRsp(MethodResultBase methodReultBase) : base(methodReultBase)
        {
            PagingResult<T> pagingResult = methodReultBase as PagingResult<T>;
            if (pagingResult != null)
            {
                Data = pagingResult.Data;
                PageIndex = pagingResult.PageIndex;
                PageSize = pagingResult.PageSize;
                Total = pagingResult.Total;
            }
        }

        /// <summary>
        /// 当前页索引
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public int Total { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}