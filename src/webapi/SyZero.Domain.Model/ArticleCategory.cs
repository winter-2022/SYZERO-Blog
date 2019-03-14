
using System.ComponentModel.DataAnnotations;

namespace SyZero.Domain.Model
{
    public class ArticleCategory : EfEntityBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(200)]
        public string Name { get; set; }
        /// <summary>
        /// 种类
        /// </summary>
        public string TypeCode { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public long ParentID { get; set; }
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
    }
}
