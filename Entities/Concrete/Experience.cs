using Entities.Abstract;
using Entities.Concrete.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("Experiences")]
    public class Experience : EntityBase, IEntity
    {

    }
}
