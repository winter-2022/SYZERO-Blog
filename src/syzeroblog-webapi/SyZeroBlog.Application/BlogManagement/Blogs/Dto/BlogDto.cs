﻿using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Application.Service.Dto;
using SyZeroBlog.Application.BlogManagement.Categorys.Dto;
using SyZeroBlog.Application.Users.Dto;
using SyZeroBlog.Core.Authorization.Users;

namespace SyZeroBlog.Application.BlogManagement.Blogs.Dto
{
    public class BlogDto :EntityDto
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public long? CreateUserId { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string CreateUserName { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public long? CategoryId { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public int CommentNums { get; set; }
        /// <summary>
        /// 查看次数
        /// </summary>
        public int ViewNums { get; set; }
    }
}