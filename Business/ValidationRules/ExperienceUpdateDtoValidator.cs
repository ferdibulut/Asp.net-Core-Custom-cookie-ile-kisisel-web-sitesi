using Entities.Dtos.ExperienceDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class ExperienceUpdateDtoValidator:AbstractValidator<ExperienceUpdateDto>
    {
        public ExperienceUpdateDtoValidator()
        {
            RuleFor(x => x.Id).InclusiveBetween(1,int.MaxValue).WithMessage("Id Alanı Boş Bırakılamaz");
            RuleFor(I => I.Title).NotEmpty().WithMessage("Başlık Boş Bırakılamaz");
            RuleFor(I => I.SubTitle).NotEmpty().WithMessage("Alt Başlık Boş Bırakılamaz");
            RuleFor(I => I.StartDate).NotEmpty().WithMessage("Başlangıç Tarihi Boş Bırakılamaz");
            RuleFor(I => I.Description).NotEmpty().WithMessage("Acıklama Alanı Boş Bırakılamaz");

        }
    }
}
