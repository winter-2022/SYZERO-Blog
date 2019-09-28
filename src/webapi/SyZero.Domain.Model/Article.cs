
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyZero.Domain.Model
{
    /// <summary>
    /// 文章表
    /// </summary>
    [Table("sy_article")]
    public class Article : EntityBase
    {
        #region 文章属性
        /// <summary>
        /// 标题
        /// </summary>
        [MaxLength(200)]
        [Column("title")]
        public string Title { get; set; }
        /// <summary>
        /// 分类Id
        /// </summary>
        [Column("cate_id")]
        public long CateId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [Column("user_id")]
        public long UserId { get; set; }
        /// <summary>
        /// 缩略图Id
        /// </summary>
        [Column("thumbnail_id")]
        public long ThumbnailId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Column("status")]
        public int Status { get; set; }
        /// <summary>
        /// 简述
        /// </summary>
        [Column("description", TypeName = "text")]
        public string Description { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Column("content",TypeName="text")]
        public string Content { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        [MaxLength(500)]
        [Column("tag")]
        public string Tag { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        [Column("browse_count")]
        public int BrowseCount { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [Column("add_time",TypeName = "datetime")]
        public System.DateTime AddTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Column("update_time",TypeName = "datetime")]
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
