using IntroNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.AdSoyad = "Türkay Ürkmez";
            ViewBag.Saat = DateTime.Now.Hour;
            return View();
        }
        [HttpGet]
        public IActionResult Katil()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Katil(Katilimci katilimci)
        {
            if (ModelState.IsValid)
            {
                return Json("Kayit basarili");
            }
            return View();
        }


    }
}
