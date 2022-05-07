using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.EducationDtos;
using Entities.Dtos.ExperienceDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FbProje.PersonalUl.Areas.Admin.Controllers.AdminHome
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class ExperienceController : Controller
    {
        private readonly IGenericService<Experience> _experienceGenericService;
        private readonly IMapper _mapper;
        public ExperienceController(IGenericService<Experience> genericService, IMapper mapper)
        {
            _experienceGenericService = genericService;
            _mapper = mapper;
        }

        [Area("Admin")]
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            TempData["active"] = "Deneyim";
            return View(_mapper.Map<List<ExperienceListDto>>(_experienceGenericService.GetAll()));
            
        }
        public IActionResult Add()
        {
            TempData["active"] = "deneyim";
            return View(new ExperienceAddDto());
        }
        [HttpPost]
        public IActionResult Add(ExperienceAddDto model)
        {
            TempData["active"] = "deneyim";
            if (ModelState.IsValid)
            {
                _experienceGenericService.Insert(_mapper.Map<Experience>(model));
                TempData["message"] = "Ekleme işlemi başarılı";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Update(int id)
        {
            TempData["active"] = "deneyim";

            return View(_mapper.Map<ExperienceUpdateDto>(_experienceGenericService.GetById(id))); ;
        }
        [HttpPost]
        public IActionResult Update(ExperienceUpdateDto model)
        {
            TempData["active"] = "deneyim";
            if (ModelState.IsValid)
            {
                var updatedExperience = _experienceGenericService.GetById(model.Id);
                updatedExperience.Description = model.Description;
                updatedExperience.StartDate=  model.StartDate;
                updatedExperience.SubTitle = model.SubTitle;
                updatedExperience.Title = model.Title;
                updatedExperience.EndDate = model.EndDate;
                _experienceGenericService.Update(updatedExperience);
                TempData["message"] = "Güncelleme işleminiz başarılı";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            TempData["active"] = "deneyim";
            var deletedExperience = _experienceGenericService.GetById(id);
            _experienceGenericService.Delete(deletedExperience);
            TempData["message"] = "Silme işlemi başarılı";
            return RedirectToAction("Index");
        }
    }
}
