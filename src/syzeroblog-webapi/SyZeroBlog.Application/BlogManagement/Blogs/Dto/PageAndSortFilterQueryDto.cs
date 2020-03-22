using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Application.Service.Dto;

namespace SyZeroBlog.Application.BlogManagement.Blogs.Dto
{
    public class PageAndSortFilterQueryDto : PageAndSortQueryDto
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public long? CategoryId { get; set; }
    }
}
