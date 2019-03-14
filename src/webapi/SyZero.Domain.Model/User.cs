﻿
using System.ComponentModel.DataAnnotations;

namespace SyZero.Domain.Model
{
    public class User : EfEntityBase
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(200)]
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(200)]
        public string Password { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(200)]
        public string Mail { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [MaxLength(200)]
        public string Phone { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [MaxLength(1000)]
        public string Photo { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public int Utype { get; set; }
        /// <summary>
        /// 性别  0男  1女  2保密
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public System.DateTime AddTime { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public System.DateTime LastTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }
    }
}
