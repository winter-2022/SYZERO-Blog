
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyZero.Domain.Model
{
    /// <summary>
    /// 评论表
    /// </summary>
    [Table("sy_comment")]
    public class Comment : EntityBase
    {
        #region 属性
        /// <summary>
        /// 用户Id
        /// </summary>
        [Column("user_id")]
        public long UserId { get; set; }
        /// <summary>
        /// 文章Id
        /// </summary>
        [Column("article_id")]
        public long ArticleId { get; set; }
        /// <summary>
        /// 上级Id
        /// </summary>
        [Column("parent_id")]
        public long ParentId { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [MaxLength(200)]
        [Column("user_name")]
        public string UserName { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(200)]
        [Column("user_email")]
        public string UserEmail { get; set; }
        /// <summary>
        /// 用户IP
        /// </summary>
        [MaxLength(200)]
        [Column("user_ip")]
        public string UserIP { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [MaxLength(2000)]
        [Column("content")]
        public string Content { get; set; }
        /// <summary>
        /// 发表时间
        /// </summary>
        [Column("add_time", TypeName = "datetime")]
        public System.DateTime AddTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Column("status")]
        public int Status { get; set; }
        #endregion

      
    }
}
