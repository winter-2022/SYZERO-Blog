using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SyZero.Common;

namespace SyZero.Domain.Model
{
    public class EntityBase : IEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; } = SnowflakeId.GetID();

    }
}
