using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Common;

namespace SyZero.Domain.Model
{
    public class EntityBase : IEntity
    {
        public string Id { get; set; } = SnowflakeId.GetID();

    }
}
