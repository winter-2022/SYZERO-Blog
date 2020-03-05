using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Domain.Entities;
using SyZeroBlog.Core.Authorization.Users;
using SyZeroBlog.Core.BlogManagement.Categorys;
using SyZeroBlog.Core.BlogManagement.Comments;

namespace SyZeroBlog.Core.BlogManagement.Blogs
{
    /// <summary>
    /// 博文
    /// </summary>
    public class Blog :Entity
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// 分类Id
        /// </summary>
        public long? CategoryId { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public virtual BlogCategory Category { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public virtual ICollection<BlogTag>  BlogTags { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; } = 0;
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 是否顶置
        /// </summary>
        public bool IsTop { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; } = 0;
        /// <summary>
        /// 点赞次数
        /// </summary>
        public int LikeNums { get; set; } = 0;
        /// <summary>
        /// 查看次数
        /// </summary>
        public int ViewNums { get; set; } = 0;
        /// <summary>
        /// 创建人
        /// </summary>
        public virtual User CreateUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 评论
        /// </summary>
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
