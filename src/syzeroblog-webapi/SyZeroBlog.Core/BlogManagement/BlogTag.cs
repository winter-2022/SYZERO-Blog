using System;
using System.Collections.Generic;
using System.Text;
using SyZeroBlog.Core.BlogManagement.Blogs;
using SyZeroBlog.Core.BlogManagement.Tags;

namespace SyZeroBlog.Core.BlogManagement
{
    public class BlogTag
    {
        public long BlogId { get; set; }
        public virtual Blog Blog { get; set; }

        public long TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
