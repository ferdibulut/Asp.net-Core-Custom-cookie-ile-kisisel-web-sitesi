using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.AppUserDtos;
using Entities.Dtos.CertificationDtos;
using Entities.Dtos.EducationDtos;
using Entities.Dtos.ExperienceDtos;
using Entities.Dtos.InterestDtos;
using Entities.Dtos.SkillDtos;
using Entities.Dtos.SocialMediaIconDtos;

namespace FbProje.PersonalUl.Mapping
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<AppUser,AppUserListDto>();
            CreateMap<AppUserListDto,AppUser>();

            CreateMap<Certification,CertificationListDto>();
            CreateMap<CertificationListDto,Certification>();

            CreateMap<CertificationAddDto, Certification>();
            CreateMap<Certification, CertificationAddDto>();

            CreateMap<CertificationUpdateDto, Certification>();
            CreateMap<Certification,CertificationUpdateDto>();

            CreateMap<Education, EducationListDto>();
            CreateMap<EducationListDto,Education>();

            CreateMap<Education, EducationAddDto>();
            CreateMap<EducationAddDto, Education>();

            CreateMap<EducationUpdateDto, Education>();
            CreateMap<Education,EducationUpdateDto>();

            CreateMap<Experience, ExperienceListDto>();
            CreateMap<ExperienceListDto, Experience>();

            CreateMap<ExperienceAddDto, Experience>();
            CreateMap<Experience, ExperienceAddDto>();
            CreateMap<ExperienceUpdateDto, Experience>();
            CreateMap<Experience, ExperienceUpdateDto>();

            CreateMap<InterestListDto, Interest>();
            CreateMap<Interest, InterestListDto>();
            CreateMap<InterestAddDto, Interest>();
            CreateMap<Interest, InterestAddDto>();
            CreateMap<InterestUpdateDto, Interest>();
            CreateMap<Interest, InterestUpdateDto>();

            CreateMap<Skill, SkillListDto>();
            CreateMap<SkillListDto, Skill>();
            CreateMap<Skill, SkillAddDto>();
            CreateMap<SkillAddDto, Skill>();
            CreateMap<Skill, SkillUpdateDto>();
            CreateMap<SkillUpdateDto, Skill>();


            CreateMap<SocialMediaIcon, SocialMediaIconListDto>();
            CreateMap<SocialMediaIconListDto, SocialMediaIcon>();
            CreateMap<SocialMediaIcon, SocialMediaIconAddDto>();
            CreateMap<SocialMediaIconAddDto, SocialMediaIcon>();
            CreateMap<SocialMediaIcon, SocialMediaIconUpdateDto>();
            CreateMap<SocialMediaIconUpdateDto, SocialMediaIcon>();
        }
    }
}
