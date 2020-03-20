using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Application.Service.Dto;
using SyZeroBlog.Application.BlogManagement.Categorys.Dto;
using SyZeroBlog.Application.BlogManagement.Tags.Dto;
using SyZeroBlog.Application.Users.Dto;

namespace SyZeroBlog.Application.BlogManagement.Blogs.Dto
{
    public class CreateBlogDto : EntityDto
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
        /// 分类Id
        /// </summary>
        public long? CategoryId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 模板
        /// </summary>
        public string Template { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public  List<string> Tags { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 是否顶置
        /// </summary>
        public bool IsTop { get; set; } = false;
        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; } = 0;
        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }
     
    }
}
