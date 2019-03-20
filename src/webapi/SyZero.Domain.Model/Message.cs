
using System.ComponentModel.DataAnnotations;

namespace SyZero.Domain.Model
{
    public class Message : EfEntityBase
    {
        #region 属性
        /// <summary>
        /// 标题
        /// </summary>
        public long UserID { get; set; }
        /// <summary>
        /// 种类
        /// </summary>
        public string TypeCode { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public long ParentID { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Messages { get; set; }
        /// <summary>
        /// 详情
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
        /// 状态
        /// </summary>
        public int State { get; set; } 
        #endregion

        public void UpDate(Message message)
        {
            this.Messages = message.Messages;
            this.Content = message.Content;
          
        }
    }
}
