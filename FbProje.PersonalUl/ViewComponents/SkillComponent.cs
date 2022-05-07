using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.SkillDtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FbProje.PersonalUl.ViewComponents
{
    public class SkillComponent:ViewComponent
    {
        private readonly IGenericService<Skill> _genericService;
        private readonly IMapper _mapper;

        public SkillComponent(IMapper mapper, IGenericService<Skill> genericService)
        {
            _mapper = mapper;
            _genericService = genericService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<List<SkillListDto>>(_genericService.GetAll()));
        }
    }
}
