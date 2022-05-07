using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.SkillDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FbProje.PersonalUl.Areas.Admin.Controllers.AdminHome
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        private readonly IGenericService<Skill> _genericService;
        private readonly IMapper _mapper;

        public SkillController(IGenericService<Skill> genericService, IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["active"] = "yetenek";
            return View(_mapper.Map<List<SkillListDto>>(_genericService.GetAll()));
        }
        public IActionResult Add()
        {
            TempData["active"] = "yetenek";
            return View(new SkillAddDto());
        }
        [HttpPost]
        public IActionResult Add(SkillAddDto model)
        {
            TempData["active"] = "yetenek";
            if (ModelState.IsValid)
            {
                _genericService.Insert(_mapper.Map<Skill>(model));
                TempData["message"] = "Ekleme İşlemi Başarılı";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Update(int id)
        {
            TempData["active"] = "yetenek";
            return View(_mapper.Map<SkillUpdateDto>(_genericService.GetById(id)));
        }
        [HttpPost]
        public IActionResult Update(SkillUpdateDto model)
        {
            TempData["active"] = "yetenek";
            if (ModelState.IsValid)
            {
                var updateSkill = _genericService.GetById(model.Id);
                updateSkill.Description = model.Description;
                _genericService.Update(updateSkill);
                TempData["message"] = "Güncelleme Başarılı";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            TempData["active"] = "yetenek";
            var deleteSkill = _genericService.GetById(id);
            _genericService.Delete(deleteSkill);
            TempData["message"] = "Silme İşlemi Başarılı";  
            return RedirectToAction("Index");
        }
    }
}
