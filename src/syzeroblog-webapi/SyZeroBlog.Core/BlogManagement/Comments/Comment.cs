﻿using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Domain.Entities;
using SyZeroBlog.Core.Authorization.Users;
using SyZeroBlog.Core.BlogManagement.Blogs;

namespace SyZeroBlog.Core.BlogManagement.Comments
{
   public class Comment : Entity
    {

        /// <summary>
        /// 博文Id
        /// </summary>
        public long BlogId { get; set; }

        /// <summary>
        /// 博文
        /// </summary>
        public virtual Blog Blog { get; set; }

        /// <summary>
        /// 上级Id
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// 上级
        /// </summary>
        public virtual Comment Parent { get; set; }

        /// <summary>
        /// 下级
        /// </summary>
        public virtual ICollection<Comment> Childs { get; set; }

        /// <summary>
        /// 发表人
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; } = 0;
        /// <summary>
        /// IP
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

    }
}
