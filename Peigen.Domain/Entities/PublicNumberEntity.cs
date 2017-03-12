/*------------------------------------------------ 
// File Name:PublicNumber.cs 
// File Description:PublicNumber DataBase Entity 
// Author:Gen 
// Create Time:2017/03/12 14:05:20 
//------------------------------------------------*/  
using System;

 
namespace Peigen.Domain.Entities
{
    public class PublicNumberEntity
    {
        /// <summary>
        /// 公众号ID
        /// </summary>
        public int F_PublicID { get;set; }        
        /// <summary>
        /// 公众号名称
        /// </summary>
        public string F_PublicName { get;set; }        
        /// <summary>
        /// 公众号原始id
        /// </summary>
        public string F_OriginalID { get;set; }        
        /// <summary>
        /// 是否认证
        /// </summary>
        public bool F_Authentication { get;set; }        
        /// <summary>
        /// AppID
        /// </summary>
        public string F_AppId { get;set; }        
        /// <summary>
        /// AppSecret
        /// </summary>
        public string F_AppSecret { get;set; }        
        /// <summary>
        /// 商家ID
        /// </summary>
        public int F_UserID { get;set; }        
        /// <summary>
        /// 1- 订阅号  2 -服务号
        /// </summary>
        public byte F_NumberType { get;set; }        
        /// <summary>
        /// 微信号
        /// </summary>
        public string F_Number { get;set; }        
        /// <summary>
        /// 公众号图标
        /// </summary>
        public string F_Icon { get;set; }        
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string F_Email { get;set; }        
        /// <summary>
        /// 行业ID
        /// </summary>
        public bool F_Selected { get;set; }        
        /// <summary>
        /// 消息加密密钥
        /// </summary>
        public string F_EncodingAESKey { get;set; }        
        /// <summary>
        /// 上班时间
        /// </summary>
        public string F_WorkTime { get;set; }        
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime F_CreateDate { get;set; }        
    }
}