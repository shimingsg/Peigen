using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peigen.Common
{
    public class MethodResultFull<T>:MethodResultBase
    {
        public T Content { get; set; }

        public MethodResultFull() : this(ModuleCodeEnum.Success, 0)
        {

        }

        public MethodResultFull(ModuleCodeEnum moduleCode, int statusCode) : base(moduleCode, statusCode)
        {
        }

        public MethodResultFull(T defaultValue):this(ModuleCodeEnum.Success, 0, defaultValue)
        {

        }

        public MethodResultFull(ModuleCodeEnum moduleCode, int statusCode, T defaultValue) : this(moduleCode, statusCode)
        {
            this.Content = defaultValue;
        }

        public MethodResultFull(MethodResultBase methodReultBase) : base(methodReultBase)
        {

        }

        public override bool IsSuccess()
        {
            return this.ResultNo == ModuleCodeHelper.Success && this.Content != null;
        }
    }
}
