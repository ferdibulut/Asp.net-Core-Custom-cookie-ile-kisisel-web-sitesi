using Entities.Dtos.SkillDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class SkillUpdateDtoValidator:AbstractValidator<SkillUpdateDto>
    {
        public SkillUpdateDtoValidator()
        {
            RuleFor(I => I.Id).InclusiveBetween(1, int.MaxValue).WithMessage("Id Alanı Boş Geçilemez");
            RuleFor(I => I.Description).NotEmpty().WithMessage("Acıklama Alanı Boş Gecilemez");
        }
    }
}
