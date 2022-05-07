using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.EducationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FbProje.PersonalUl.Areas.Admin.Controllers.AdminHome
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class EducationController:Controller
    {
        private readonly IGenericService<Education> _educationGenericService;
        private readonly IMapper _mapper;

        public EducationController(IGenericService<Education> educationGenericService, IMapper mapper)
        {
            _educationGenericService = educationGenericService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["active"] = "egitim";
            return View(_mapper.Map<List<Education>>(_educationGenericService.GetAll()));
        }
        public IActionResult Delete(int id)
        {
            var deletedEntity=_educationGenericService.GetById(id);
            _educationGenericService.Delete(deletedEntity);
            TempData["message"] = "Silme işlemi başarılı";
            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {
            TempData["active"] = "egitim";
            return View(new EducationAddDto());
        }
        [HttpPost]
        public IActionResult Add(EducationAddDto model)
        {
            if (ModelState.IsValid)
            {
                _educationGenericService.Insert(_mapper.Map<Education>(model));
                TempData["message"] = "Ekleme işlemi başarılı";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Update(int id)
        {
            TempData["active"] = "egitim";
            return View(_mapper.Map<EducationUpdateDto>(_educationGenericService.GetById(id)));
        }
        [HttpPost]
        public IActionResult Update(EducationUpdateDto model)
        {
            TempData["active"] = "egitim";
            if (ModelState.IsValid)
            {
                var updatedEducation = _educationGenericService.GetById(model.Id);
                updatedEducation.StartDate=model.StartDate;
                updatedEducation.EndDate=model.EndDate;
                updatedEducation.Description=model.Description;
                updatedEducation.SubTitle=model.SubTitle;
                updatedEducation.Title=model.Title;
                _educationGenericService.Update(updatedEducation);
                TempData["message"] = "Güncelleme İşlemi Başarılı";
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
