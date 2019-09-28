
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyZero.Domain.Model
{
    /// <summary>
    /// 文件表
    /// </summary>
    [Table("sy_file")]
    public class File : EntityBase
    {
        #region 属性
        /// <summary>
        /// 用户Id
        /// </summary>
        [Column("user_id")]
        public long UserId { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        [Column("size")]
        public int Size { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        [MaxLength(200)]
        [Column("name")]
        public string Name { get; set; }
        /// <summary>
        /// 原文件名
        /// </summary>
        [MaxLength(200)]
        [Column("source_name")]
        public string SourceName { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        [MaxLength(200)]
        [Column("type")]
        public string Type { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        [Column("upload_time", TypeName = "datetime")]
        public System.DateTime UploadTime { get; set; }
        #endregion


    }
}
