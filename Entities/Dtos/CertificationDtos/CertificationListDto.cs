using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.CertificationDtos
{
    public class CertificationListDto : IDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
