﻿using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Runtime.Entities;

namespace SyZeroBlog.Web.Core.Models
{
    public class ResultModel
    {
        /// <summary>
        /// 自定义
        /// </summary>
        /// <param name="data">数据对象 例如:{status=500,action="6666"}</param>
        /// <param name="msgStatus"></param>
        public ResultModel(object Data)
        {
            this.code = (int)SyMessageBoxStatus.成功;
            this.data = Data;
        }

        /// <summary>
        /// 成功状态码
        /// </summary>
        public int code { set; get; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public object data { set; get; }
    }
}
