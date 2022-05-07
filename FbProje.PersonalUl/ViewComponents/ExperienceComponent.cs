using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.ExperienceDtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FbProje.PersonalUl.ViewComponents
{
    public class ExperienceComponent:ViewComponent
    {
        private readonly IGenericService<Experience> _genericService;
        private readonly IMapper _mapper;
        public ExperienceComponent(IGenericService<Experience> genericService, IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<List<ExperienceListDto>>(_genericService.GetAll()));
        }
    }
}
