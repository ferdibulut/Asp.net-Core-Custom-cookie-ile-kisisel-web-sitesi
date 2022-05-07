using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.SkillDtos
{
    public class SkillAddDto:IDto
    {
        public string Description { get; set; }
    }
}
