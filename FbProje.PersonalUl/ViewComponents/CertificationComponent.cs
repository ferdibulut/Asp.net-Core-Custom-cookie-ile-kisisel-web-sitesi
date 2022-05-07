using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.CertificationDtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FbProje.PersonalUl.ViewComponents
{
    public class CertificationComponent:ViewComponent
    {
        private readonly  IGenericService<Certification> _genericService;
        private readonly  IMapper _mapper;

        public CertificationComponent(IMapper mapper, IGenericService<Certification> genericService)
        {
            _mapper = mapper;
            _genericService = genericService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<List<CertificationListDto>>(_genericService.GetAll()));
        }
    }
}
