
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyZero.Domain.Model
{
    /// <summary>
    /// 导航表
    /// </summary>
    [Table("sy_navigation")]
    public class Navigation : EntityBase
    {
        #region 属性
        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(200)]
        [Column("name")]
        public string Name { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [MaxLength(200)]
        [Column("icon")]
        public string Icon { get; set; }
        /// <summary>
        /// 上级Id
        /// </summary>
        [Column("parent_id")]
        public long ParentId { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        [MaxLength(1000)]
        [Column("url")]
        public string Url { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Column("sort")]
        public int Sort { get; set; }
        /// <summary>
        /// 是否新窗口打开
        /// </summary>
        [Column("is_blank")]
        public int IsBlank { get; set; }

        #endregion


    }
}
