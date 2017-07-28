using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peigen.Common
{
    public class PagingResult<T>
    {
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

        public PagingResult()
        {
        }

        public PagingResult(int pageIndex, int pageSize, int total, IEnumerable<T> valueList)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Total = total;
            Data = valueList;
        }
    }
}
