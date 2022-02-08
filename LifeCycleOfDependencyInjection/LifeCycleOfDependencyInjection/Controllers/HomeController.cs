using LifeCycleOfDependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCycleOfDependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISingletonGenerator singleton;
        private readonly IScopedGenerator scoped;
        private readonly ITransientGenerator transient;
        private readonly UnderstandingScoped understanding;

        public HomeController(ILogger<HomeController> logger, ISingletonGenerator singleton, IScopedGenerator scoped, ITransientGenerator transient, UnderstandingScoped understanding)
        {
            _logger = logger;
            this.singleton = singleton;
            this.scoped = scoped;
            this.transient = transient;
            this.understanding = understanding;
        }

        public IActionResult Index()
        {
            ViewBag.Singleton = singleton.Guid;
            ViewBag.Transient = transient.Guid;
            ViewBag.Scoped = scoped.Guid;

            ViewBag.SingletonService = understanding.Singleton.Guid;
            ViewBag.ScopedService = understanding.Scoped.Guid;
            ViewBag.TransientService = understanding.Transient.Guid;


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
