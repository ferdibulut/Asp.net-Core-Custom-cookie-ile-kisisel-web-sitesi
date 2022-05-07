using Business.Abstract;
using Entities.Concrete;
using FbProje.PersonalUl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FbProje.PersonalUl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericService<Skill> _genericService;
        public HomeController(ILogger<HomeController> logger, IGenericService<Skill> genericService)
        {
            _logger = logger;
            _genericService = genericService;
        }

        public IActionResult Index()
        {

           return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
