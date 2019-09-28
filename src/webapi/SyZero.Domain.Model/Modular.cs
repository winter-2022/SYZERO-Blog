
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyZero.Domain.Model
{
    /// <summary>
    /// 模块表
    /// </summary>
    [Table("sy_modular")]
    public class Modular : EntityBase
    {
        #region 属性
        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(200)]
        [Column("name")]
        public string Name { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Column("content", TypeName = "text")]
        public string Content { get; set; }
     
        #endregion

     
    }
}
