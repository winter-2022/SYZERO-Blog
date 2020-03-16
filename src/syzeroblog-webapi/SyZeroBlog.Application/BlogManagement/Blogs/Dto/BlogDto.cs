using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Application.Service.Dto;

namespace SyZeroBlog.Application.BlogManagement.Blogs.Dto
{
    public class BlogDto :EntityDto
    {
        public string Title { get; set; }

        public string Alias { get; set; }



    }
}
