
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyZero.Domain.Model
{
    /// <summary>
    /// 标签表
    /// </summary>
    [Table("sy_tag")]
    public class Tag : EntityBase
    {
        #region 属性
        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(200)]
        [Column("name")]
        public string Name { get; set; }
        /// <summary>
        /// 别名
        /// </summary>
        [MaxLength(200)]
        [Column("alias")]
        public string Alias { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Column("sort")]
        public int Sort { get; set; }
        /// <summary>
        /// 点击次数
        /// </summary>
        [Column("click_count")]
        public int ClickCount { get; set; }
        #endregion


    }
}
