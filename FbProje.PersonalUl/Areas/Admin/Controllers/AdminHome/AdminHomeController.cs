using Business.Abstract;
using Entities.Dtos.AppUserDtos;
using FbProje.PersonalUl.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace FbProje.PersonalUl.Areas.Admin.Controllers.Home
{
    [Area("Admin")]
    [Authorize]
    public class AdminHomeController : Controller
    {
        private readonly IAppUserService _appUserService;

        public AdminHomeController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
          TempData["active"] = "bilgilerim";
          var user= _appUserService.FindByName(User.Identity.Name);
          var appUserUpdateModel = new AppUserUpdateModel()
            {
                Email = user.Email,
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ImageUrl = user.ImageUrl,
                PhoneNumber = user.PhoneNumber,
                ShortDescription = user.ShortDescription,
                Id = user.Id
            };
            return View(appUserUpdateModel);
        }
        [HttpPost]
        public IActionResult Index(AppUserUpdateModel model) 
        {
            TempData["active"] ="bilgilerim";
            if (ModelState.IsValid)
            {
                var uppdatedAppUser = _appUserService.GetById(model.Id);
                if (model.Picture!=null)
                {
                    //uygulama/wwwroot/img/dsas-dsad-dasd-dsaa.png
                    var imgName = Guid.NewGuid() + Path.GetExtension(model.Picture.FileName);
                    var path= Directory.GetCurrentDirectory() + "/wwwroot/img/"+imgName;
                    var stream = new FileStream(path,FileMode.Create);
                    model.Picture.CopyTo(stream);
                    uppdatedAppUser.ImageUrl = imgName;
                    //model.Picture.CopyTo()
                }
                uppdatedAppUser.LastName = model.LastName;
                uppdatedAppUser.FirstName = model.FirstName;
                uppdatedAppUser.PhoneNumber = model.PhoneNumber;
                uppdatedAppUser.ShortDescription = model.ShortDescription;
                uppdatedAppUser.Address = model.Address;
                uppdatedAppUser.Email = model.Email;
                _appUserService.Update(uppdatedAppUser);
                TempData["Message"] = "İşleminiz başarı ile gercekleşti";
                return RedirectToAction("Index");
              
            }
            return View(model);
        }
        public IActionResult ChangePassword()
        { 
            TempData["active"] = "sifre";
            var user = _appUserService.FindByName(User.Identity.Name);
            return View(new AppUserPasswordDto { Id=user.Id});
        }
        [HttpPost]
        public IActionResult ChangePassword(AppUserPasswordDto model)
        {
            TempData["active"] = "sifre";
            if (ModelState.IsValid)
            {
                var updatedUser = _appUserService.FindByName(User.Identity.Name);
                updatedUser.Password = model.Password;
                _appUserService.Update(updatedUser);
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            return View(model);
        }

    }
}
