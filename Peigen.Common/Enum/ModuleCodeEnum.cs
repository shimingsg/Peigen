using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peigen.Common
{
    /// <summary>
    /// 模块编码枚举
    /// </summary>
    public enum ModuleCodeEnum
    {
        /// <summary>
        /// 请求成功
        /// </summary>
        Success = 0000,

        /// <summary>
        /// 核心模块-用户所在省市区信息
        /// </summary>
        Core_Area = 0101,

        /// <summary>
        /// 系统-项目中的所有配置信息
        /// </summary>
        Sys_Config = 0201,

        /// <summary>
        /// 系统 - 框架级别的错误
        /// </summary>
        Sys_Framework = 0202,

        /// <summary>
        /// 系统基础权限
        /// </summary>
        Sys_Permission = 0203,

        /// <summary>
        /// 系统角色
        /// </summary>
        Sys_Role = 0204,

        /// <summary>
        /// 系统访问日志
        /// </summary>
        Sys_SiteAccessLog = 0205,
    }
}