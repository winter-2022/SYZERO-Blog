
using System;
using System.ComponentModel.DataAnnotations;
using SyZero.Common;
namespace SyZero.Domain.Model
{
    public class User : EntityBase
    {
        #region 用户属性
        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(200)]
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(200)]
        public string Password { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(200)]
        public string Mail { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [MaxLength(200)]
        public string Phone { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [MaxLength(1000)]
        public string Photo { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public int Utype { get; set; }
        /// <summary>
        /// 性别  0男  1女  2保密
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public System.DateTime AddTime { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public System.DateTime LastTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; } 
        #endregion
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user"></param>
        public void UpDateInfo(User user)
        {
            this.Name = user.Name;
            this.Phone = user.Phone;
            this.Photo = user.Photo;
            this.Sex = user.Sex;
        }
        /// <summary>
        /// 停用此用户
        /// </summary>
        public void Delete()
        {
            this.State = -1;
        }

        public User(string name,string paw,int sex,string mail,string phone)
        {
            this.Id = SnowflakeId.GetID();
            this.Name = name;
            this.Password = paw;
            this.AddTime = DateTime.Now;
            this.State = 1;
            this.Sex = sex;
            this.Mail = mail;
            this.Phone = phone;
        }

        public User AddUser()
        {
            this.Id = SnowflakeId.GetID();
            this.AddTime = DateTime.Now;
            return this;
        }

        public User()
        {

        }
    }
}
