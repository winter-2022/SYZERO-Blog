
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyZero.Domain.Model
{
    /// <summary>
    /// 文章分类表
    /// </summary>
    [Table("sy_category")]
    public class Category : EntityBase
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
        /// 上级Id
        /// </summary>
        [Column("parent_id")]
        public long ParentId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Column("sort")]
        public int Sort { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Column("status")]
        public int Status { get; set; }
        /// <summary>
        /// SEO关键字
        /// </summary>
        [MaxLength(500)]
        [Column("seo_keywords")]
        public string SeoKeywords { get; set; }
        /// <summary>
        /// SEO描述
        /// </summary>
        [MaxLength(1000)]
        [Column("seo_description")]
        public string SeoDescription { get; set; }
        #endregion
    }
}
