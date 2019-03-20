
using System;
using System.ComponentModel.DataAnnotations;

namespace SyZero.Domain.Model
{
    public class SiteConfig : EfEntityBase
    {
        #region 属性
        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public long ParentID { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
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
        #endregion

        public void UpDate(SiteConfig site)
        {
            this.Key = site.Key;
            this.Value = site.Value;
            this.UpdateTime = DateTime.Now;
          
        }
    }
}
