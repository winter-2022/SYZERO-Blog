
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SyZero.Common;
namespace SyZero.Domain.Model
{
    [Table("sy_user")]
    public class User : EntityBase
    {
        #region 用户属性
        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(200)]
        [Column("name")]
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(200)]
        [Column("password")]
        public string Password { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(200)]
        [Column("mail")]
        public string Mail { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [MaxLength(200)]
        [Column("phone")]
        public string Phone { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [Column("picture_id")]
        public long PictureId { get; set; }
        /// <summary>
        /// 用户等级
        /// </summary>
        [Column("level")]
        public int Level { get; set; }
        /// <summary>
        /// 性别  0男  1女  2保密
        /// </summary>
        [Column("sex")]
        public int Sex { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        [Column("add_time", TypeName = "datetime")]
        public System.DateTime AddTime { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        [Column("last_time", TypeName = "datetime")]
        public System.DateTime LastTime { get; set; }
        /// <summary>
        /// 最后登录IP
        /// </summary>
        [MaxLength(200)]
        [Column("last_ip")]
        public string LastIP { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        [Column("type")]
        public int Type { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Column("status")]
        public int Status { get; set; } 
        #endregion
     

    }
}
