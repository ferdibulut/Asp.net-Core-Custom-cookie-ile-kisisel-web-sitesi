using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.SocialMediaIconDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FbProje.PersonalUl.Areas.Admin.Controllers.AdminHome
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class SocialMediaIconController : Controller
    {
        private readonly IAppUserService _userService;
        private readonly ISocialMediaIconService _socialMediaIconService;
        private readonly IGenericService<SocialMediaIcon> _genericService;
        private readonly IMapper _mapper;
        public SocialMediaIconController(IGenericService<SocialMediaIcon> genericService, IMapper mapper, IAppUserService userService, ISocialMediaIconService socialMediaIconService)
        {
            _genericService = genericService;
            _mapper = mapper;
            _userService = userService;
            _socialMediaIconService = socialMediaIconService;
        }


        public IActionResult Index()
        {
            var user= _userService.FindByName(User.Identity.Name);
            TempData["active"] = "ikon";
            return View(_mapper.Map<List<SocialMediaIconListDto>>(_socialMediaIconService.GetByUserId(user.Id)));
        }
        public IActionResult Add()
        {
            TempData["active"] = "ikon";
            return View(new SocialMediaIconAddDto());
        }
        [HttpPost]
        public IActionResult Add(SocialMediaIconAddDto model)
        {
            TempData["active"] = "ikon";
            if (ModelState.IsValid)
            {
                var user = _userService.FindByName(User.Identity.Name);
                model.AppUserId=user.Id;
                _socialMediaIconService.Insert(_mapper.Map<SocialMediaIcon>(model));
                TempData["message"] = "Ekleme İşlmei Başarılı";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Update(int id)
        {
            TempData["Active"] = "ikon";
            return View(_mapper.Map<SocialMediaIconUpdateDto>(_socialMediaIconService.GetById(id)));
        }
        [HttpPost]
        public IActionResult Update(SocialMediaIconUpdateDto model)
        {
            TempData["active"] = "ikon";
            if (ModelState.IsValid)
            {
                var user= _userService.FindByName(User.Identity.Name);
                var updatedSocialMediaIcon=_socialMediaIconService.GetById(model.Id);
                updatedSocialMediaIcon.AppUserId=user.Id;
                updatedSocialMediaIcon.Icon=model.Icon;
                updatedSocialMediaIcon.Link=model.Link;
                _socialMediaIconService.Update(updatedSocialMediaIcon);
                TempData["message"] = "Güncelleme işlemi başarılı";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            TempData["active"] = "ikon";
            var deleteIcon = _socialMediaIconService.GetById(id);
            _socialMediaIconService.Delete(deleteIcon);
            TempData["message"] = "Silme İşlemi Başarılı";
            return RedirectToAction("Index");
        }
    }
}
