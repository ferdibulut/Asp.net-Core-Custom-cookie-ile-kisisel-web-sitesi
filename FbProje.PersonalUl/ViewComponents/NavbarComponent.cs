using AutoMapper;
using Business.Abstract;
using Entities.Dtos.AppUserDtos;
using Microsoft.AspNetCore.Mvc;

namespace FbProje.PersonalUl.ViewComponents
{
    public class NavbarComponent:ViewComponent
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public NavbarComponent(IAppUserService appUserService, IMapper mapper)
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
