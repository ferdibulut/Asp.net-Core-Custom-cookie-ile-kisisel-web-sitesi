using Dapper.Contrib.Extensions;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.BaseEntity
{
    public class BaseEntity2: IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
