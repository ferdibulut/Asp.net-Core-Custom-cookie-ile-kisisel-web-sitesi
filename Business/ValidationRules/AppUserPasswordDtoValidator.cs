using Entities.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class AppUserPasswordDtoValidator:AbstractValidator<AppUserPasswordDto>
    {
        public AppUserPasswordDtoValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola Boş Gecilemez");
            RuleFor(x=>x.ConfirmPassword).NotEmpty().WithMessage("Parola Tekrar Boş Gecilemez");
            RuleFor(x => x.ConfirmPassword).Equal(I=>I.Password).WithMessage("Parolalar Uyuşmuyor");
        }
    }
}
