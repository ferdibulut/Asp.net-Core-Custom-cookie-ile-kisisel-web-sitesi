using Entities.Dtos.SocialMediaIconDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class SocialMediaIconUpdateDtoValidator:AbstractValidator<SocialMediaIconUpdateDto>
    {
        public SocialMediaIconUpdateDtoValidator()
        {
            RuleFor(I => I.Id).InclusiveBetween(1, int.MaxValue).WithMessage("Id Boş Geçilemez");
            RuleFor(I => I.Icon).NotEmpty().WithMessage("ikon Boş Gecilemez");
            RuleFor(I => I.Link).NotEmpty().WithMessage("Link Boş Gecilemez");
        }
    }
}
