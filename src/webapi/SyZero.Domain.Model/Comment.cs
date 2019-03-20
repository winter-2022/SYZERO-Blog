
using System;
using System.ComponentModel.DataAnnotations;

namespace SyZero.Domain.Model
{
    public class Comment : EfEntityBase
    {
        #region 属性
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserID { get; set; }
        /// <summary>
        /// 种类
        /// </summary>
        public long ArticleID { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public long ParentID { get; set; }
        /// <summary>
        /// 内容
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
        /// 点赞数
        /// </summary>
        public int FabulousCount { get; set; } 
        #endregion

        public void UpDate(Comment comment)
        {
            this.Content = comment.Content;
            this.UpdateTime = DateTime.Now;
          
        }
    }
}
