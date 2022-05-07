using Entities.Dtos.SocialMediaIconDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class SocialMediaIconAddDtoValidator:AbstractValidator<SocialMediaIconAddDto>
    {
        public SocialMediaIconAddDtoValidator()
        {
            RuleFor(I => I.Icon).NotEmpty().WithMessage("İkon Boş Bırakılamaz");
            RuleFor(I => I.Link).NotEmpty().WithMessage("Link Boş Bırakılamaz");
            
        }
    }
}
