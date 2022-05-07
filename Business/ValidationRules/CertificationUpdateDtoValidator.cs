using Entities.Dtos.CertificationDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CertificationUpdateDtoValidator:AbstractValidator<CertificationUpdateDto>
    {
        public CertificationUpdateDtoValidator()
        {
            RuleFor(I => I.Id).InclusiveBetween(1, int.MaxValue).WithMessage("Id Alanı Boş Gecilemez");
            RuleFor(I => I.Description).NotEmpty().WithMessage("Sertifica Alanı Boş Gecilemez");
        }
    }
}
