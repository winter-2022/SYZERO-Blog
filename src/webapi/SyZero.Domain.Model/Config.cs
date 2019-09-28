
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyZero.Domain.Model
{
    [Table("sy_config")]
    public class Config : EntityBase
    {
        #region 属性
        /// <summary>
        /// 键
        /// </summary>
        [MaxLength(200)]
        [Column("name")]
        public string Name { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        [Column("value",TypeName = "text")]
        public string Value { get; set; }
     
        #endregion

     
    }
}
