using Entities.Dtos.InterestDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class InterestAddDtoValidator:AbstractValidator<InterestAddDto>
    {
        public InterestAddDtoValidator()
        {
            RuleFor(I=>I.Description).NotEmpty().WithMessage("Açıklama Alanı Boş Gecilemez");
        }
    }
}
