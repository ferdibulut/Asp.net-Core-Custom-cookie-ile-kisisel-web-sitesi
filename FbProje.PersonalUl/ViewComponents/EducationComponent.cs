using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.EducationDtos;
using Entities.Dtos.ExperienceDtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FbProje.PersonalUl.ViewComponents
{
    public class EducationComponent:ViewComponent
    {
        private readonly IGenericService<Education> _genericService;
        private readonly IMapper _mapper;

        public EducationComponent(IGenericService<Education> genericService, IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<List<EducationListDto>>(_genericService.GetAll()));
        }
    }
}
