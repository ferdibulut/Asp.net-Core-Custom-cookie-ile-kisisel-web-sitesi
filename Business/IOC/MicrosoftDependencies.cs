using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Dapper;
using Entities.Dtos.AppUserDtos;
using Entities.Dtos.CertificationDtos;
using Entities.Dtos.EducationDtos;
using Entities.Dtos.ExperienceDtos;
using Entities.Dtos.InterestDtos;
using Entities.Dtos.SkillDtos;
using Entities.Dtos.SocialMediaIconDtos;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IOC
{
    public static class MicrosoftDependencies
    {
        public static void AddCustomDependencies(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddTransient<IDbConnection>(con=>new SqlConnection(configuration.GetConnectionString("connectionMssql")));
          
            service.AddScoped(typeof(IGenericRepository<>),typeof(DpGenericRepository<>));
            service.AddScoped(typeof(IGenericService<>),typeof(GenericManager<>));
            service.AddScoped<IAppUserRepository, DbAppUserRepository>();
            service.AddScoped<IAppUserService, AppUserManager>();
            
            service.AddScoped<ISocialMediaIconService,SocialMediaIconManager>();
            service.AddScoped<ISocialMediaIconRepository,DpSocialMediaIconRepository>();

            service.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            service.AddTransient<IValidator<AppUserPasswordDto>, AppUserPasswordDtoValidator>();
            service.AddTransient<IValidator<CertificationAddDto>, CertificationAddDtoValidator>();
            service.AddTransient<IValidator<CertificationUpdateDto>, CertificationUpdateDtoValidator>();
            service.AddTransient<IValidator<EducationAddDto>, EducationAddDtoValidator>();
            service.AddTransient<IValidator<EducationUpdateDto>, EducationUpdateDtoValidator>();
            service.AddTransient<IValidator<ExperienceAddDto>, ExperienceAddDtoValidator>();
            service.AddTransient<IValidator<ExperienceUpdateDto>, ExperienceUpdateDtoValidator>();
            service.AddTransient<IValidator<InterestAddDto>, InterestAddDtoValidator>();
            service.AddTransient<IValidator<InterestUpdateDto>, InterestUpdateDtoValidator>();
            service.AddTransient<IValidator<SkillAddDto>, SkillAddDtoValidator>();
            service.AddTransient<IValidator<SkillUpdateDto>, SkillUpdateDtoValidator>();
            service.AddTransient<IValidator<SocialMediaIconAddDto>, SocialMediaIconAddDtoValidator>();
            service.AddTransient<IValidator<SocialMediaIconUpdateDto>, SocialMediaIconUpdateDtoValidator>();
        }
    }
}
