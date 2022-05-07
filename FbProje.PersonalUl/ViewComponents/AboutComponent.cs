using AutoMapper;
using Business.Abstract;
using Entities.Dtos.AppUserDtos;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace FbProje.PersonalUl.ViewComponents
{
    public class AboutComponent:ViewComponent
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        public AboutComponent(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<AppUserListDto>(_appUserService.GetById(1)));
        }
    }
}
