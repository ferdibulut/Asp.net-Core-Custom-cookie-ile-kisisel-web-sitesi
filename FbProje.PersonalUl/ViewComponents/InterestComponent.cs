using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.InterestDtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FbProje.PersonalUl.ViewComponents
{
    public class InterestComponent:ViewComponent
    {
        private readonly IGenericService<Interest> _genericInterestService;
        private readonly IMapper _mapper;

        public InterestComponent(IMapper mapper, IGenericService<Interest> genericInterestService)
        {
            _mapper = mapper;
            _genericInterestService = genericInterestService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<List<InterestListDto>>(_genericInterestService.GetAll()));
        }
    }
}
