using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.CertificationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FbProje.PersonalUl.Areas.Admin.Controllers.AdminHome
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class CertificationController:Controller
    {
        private readonly IGenericService<Certification> _certificationGenericService;
        private readonly IMapper _mapper;
        public CertificationController(IGenericService<Certification> certificationGenericService, IMapper mapper)
        {
            _certificationGenericService = certificationGenericService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["active"] = "sertifika";
       
            return View(_mapper.Map<List<CertificationListDto>>(_certificationGenericService.GetAll()));

        }
        public IActionResult Delete(int id)
        {
            TempData["active"] = "sertifika";
            var deletedEntity = _certificationGenericService.GetById(id);
            _certificationGenericService.Delete(deletedEntity);
            TempData["message"] = "Sertifika silindi";
            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {
            TempData["active"] = "sertifika";
            return View();
        }
        [HttpPost]
        public IActionResult Add(CertificationAddDto model)
        {
            TempData["active"] = "sertifika";
            if (ModelState.IsValid)
            {
                _certificationGenericService.Insert(_mapper.Map<Certification>(model));
                TempData["message"] = "Sertifika Eklendi";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Update(int id)
        {
            TempData["active"] = "sertifika";
           return View(_mapper.Map<CertificationUpdateDto>(_certificationGenericService.GetById(id)));
        }
        [HttpPost]
        public IActionResult Update(CertificationUpdateDto model)
        {
            TempData["active"] = "sertifika";
            if (ModelState.IsValid)
            {
                var updatedCertification=_certificationGenericService.GetById(model.Id);
                updatedCertification.Description= model.Description;
                _certificationGenericService.Update(updatedCertification);
                TempData["message"] = "Güncelleme işlemi başarılı ";
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
