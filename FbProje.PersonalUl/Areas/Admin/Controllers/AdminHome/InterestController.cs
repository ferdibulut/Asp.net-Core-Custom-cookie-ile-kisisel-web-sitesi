using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.InterestDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FbProje.PersonalUl.Areas.Admin.Controllers.AdminHome
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class InterestController : Controller
    {
        private readonly IGenericService<Interest> _genericService;
        private readonly IMapper _mapper;
        public InterestController(IGenericService<Interest> genericService, IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            TempData["active"] = "hobi";
            return View(_mapper.Map<List<InterestListDto>>(_genericService.GetAll()));
        }
        public IActionResult Add()
        {
            TempData["active"] = "hobi";
            return View(new InterestAddDto());
        }
        [HttpPost]
        public IActionResult Add(InterestAddDto model)
        {
            TempData["active"] = "hobi";
            if (ModelState.IsValid)
            {
                TempData["message"] = "Ekleme İşlemi Başarılı";
                _genericService.Insert(_mapper.Map<Interest>(model));
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        public IActionResult Update(int id)
        {
            TempData["active"] = "hobi";
            return View(_mapper.Map<InterestUpdateDto>(_genericService.GetById(id))); 

        }
        [HttpPost]
        public IActionResult Update(InterestUpdateDto model)
        {
            TempData["adtive"] = "hobi";
            if (ModelState.IsValid)
            {
                var updatedInterest = _genericService.GetById(model.Id);
                updatedInterest.Description = model.Description;
                _genericService.Update(updatedInterest);
                TempData["message"] = "Güncelleme işlemi başarılı";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            TempData["active"] = "hobi";
            var deletedInterest = _genericService.GetById(id);
            _genericService.Delete(deletedInterest);
            TempData["message"] = "Silme işlemi başarılı";
            return RedirectToAction("Index");
        }
    }
}
