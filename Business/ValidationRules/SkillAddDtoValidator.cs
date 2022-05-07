using Entities.Dtos.SkillDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class SkillAddDtoValidator:AbstractValidator<SkillAddDto>
    {
        public SkillAddDtoValidator()
        {
            RuleFor(I=>I.Description).NotEmpty().WithMessage("Acıklama Alanı Boş Gecilemez");

        }
    }
}
