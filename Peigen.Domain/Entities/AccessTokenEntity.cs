/*------------------------------------------------ 
// File Name:AccessToken.cs 
// File Description:AccessToken DataBase Entity 
// Author:Gen 
// Create Time:2017/03/12 01:59:58 
//------------------------------------------------*/
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Peigen.Domain.Entities
{
    [Table("T_AccessToken")]
    public class AccessTokenEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public int F_AccessTokenID { get;set; }        
        /// <summary>
        /// 获取到的凭证 
        /// </summary>
        public string F_AccessToken { get;set; }        
        /// <summary>
        /// 第三方用户唯一凭证
        /// </summary>
        public string F_Appid { get;set; }        
        /// <summary>
        /// 第三方用户唯一凭证密钥，即appsecret
        /// </summary>
        public string F_Secret { get;set; }        
        /// <summary>
        /// 获取时间
        /// </summary>
        public DateTime F_CreateDate { get;set; }        
    }
}