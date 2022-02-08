using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Controllers
{
    [Authorize(Roles ="Admin,Editor")]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product) {
            return View();
        }
    }
}
