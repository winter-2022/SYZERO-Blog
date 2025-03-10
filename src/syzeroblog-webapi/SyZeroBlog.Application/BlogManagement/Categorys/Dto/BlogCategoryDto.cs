﻿using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Application.Service.Dto;

namespace SyZeroBlog.Application.BlogManagement.Categorys.Dto
{
    public class BlogCategoryDto : EntityDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; } = 0;
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 上级Id
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// 下级
        /// </summary>
        public virtual ICollection<BlogCategoryDto> Childs { get; set; }

        /// <summary>
        /// 文章数量
        /// </summary>
        public int blognum { get; set; } = 0;
    }
}
