
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyZero.Domain.Model
{
    /// <summary>
    /// 导航表
    /// </summary>
    [Table("sy_page")]
    public class Page : EntityBase
    {
        #region 属性
        /// <summary>
        /// 标题
        /// </summary>
        [MaxLength(200)]
        [Column("title")]
        public string Title { get; set; }
        /// <summary>
        /// 别名
        /// </summary>
        [MaxLength(200)]
        [Column("alias")]
        public string Alias { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Column("content",TypeName = "text")]
        public string Content { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [Column("add_time", TypeName = "datetime")]
        public System.DateTime AddTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Column("update_time", TypeName = "datetime")]
        public System.DateTime UpdateTime { get; set; }
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
