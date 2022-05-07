using Entities.Dtos.ExperienceDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class ExperienceAddDtoValidator:AbstractValidator<ExperienceAddDto>
    {
        public ExperienceAddDtoValidator()
        {
            RuleFor(I => I.Title).NotEmpty().WithMessage("Başlık Boş Bırakılamaz");
            RuleFor(I => I.SubTitle).NotEmpty().WithMessage("Alt Başlık Boş Bırakılamaz");
            RuleFor(I => I.StartDate).NotEmpty().WithMessage("Başlangıç Tarihi Boş Bırakılamaz");
            RuleFor(I => I.Description).NotEmpty().WithMessage("Acıklama Alanı Boş Bırakılamaz");
        }
    }
}
