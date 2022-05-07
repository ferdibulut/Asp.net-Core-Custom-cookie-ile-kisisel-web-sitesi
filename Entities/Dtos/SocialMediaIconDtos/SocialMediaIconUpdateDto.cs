using Dapper.Contrib.Extensions;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.SocialMediaIconDtos
{
    public class SocialMediaIconUpdateDto:IDto
    {
        [Key]
        public int Id { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public int AppUserId { get; set; }
    }
}
