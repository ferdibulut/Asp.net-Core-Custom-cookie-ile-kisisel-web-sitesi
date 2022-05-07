using Entities.Abstract;
using Entities.Concrete.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("Educations")]
    public class Education : EntityBase, IEntity
    {

    }
}
