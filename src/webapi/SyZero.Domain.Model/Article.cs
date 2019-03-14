
using System.ComponentModel.DataAnnotations;

namespace SyZero.Domain.Model
{
    public class Article : EfEntityBase
    {
        /// <summary>
        /// 标题
        /// </summary>
        [MaxLength(200)]
        public string Title { get; set; }
        /// <summary>
        /// 种类
        /// </summary>
        public string TypeCode { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public long Category { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(1000)]
        public string Description { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        public string Picture { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public System.DateTime AddTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public System.DateTime UpdateTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string Tags { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 点击数
        /// </summary>
        public int ClickCount { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int FabulousCount { get; set; }
        /// <summary>
        /// 分享数
        /// </summary>
        public int ShareCount { get; set; }
        /// <summary>
        /// 评分
        /// </summary>
        public int ScoreCount { get; set; }
        /// <summary>
        /// SEO标题
        /// </summary>
        public string SEOTitle { get; set; }
        /// <summary>
        /// SEO关键字
        /// </summary>
        public string SEOKeywords { get; set; }
        /// <summary>
        /// SEO描述
        /// </summary>
        public string SEODescription { get; set; }
    }
}
