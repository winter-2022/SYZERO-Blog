using System;
using System.Collections.Generic;
using System.Text;

namespace SyZero.Domain.Model
{
    public interface IEntity
    {
        /// <summary>
        /// 实体Id
        /// </summary>
        string Id { get; set; }
    }
}
