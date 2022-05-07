using Entities.Dtos.EducationDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class EducationUpdateDtoValidator:AbstractValidator<EducationUpdateDto>
    {
        public EducationUpdateDtoValidator()
        {
            RuleFor(I => I.Id).InclusiveBetween(1, int.MaxValue).WithMessage("Id Alanı Gereklidir");
            RuleFor(I => I.Title).NotEmpty().WithMessage("Başlık Alanı Boş Gecilemez");
            RuleFor(I => I.SubTitle).NotEmpty().WithMessage("Alt Başlık Boş Bırakılamaz");
            RuleFor(I => I.Description).NotEmpty().WithMessage("Açıklama Boş Bırakılamaz");
            RuleFor(I => I.StartDate).NotEmpty().WithMessage("Başlangıc Tarihi Boş Bırakılamaz");
        }
    }
}
