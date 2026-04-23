using Microsoft.AspNetCore.Mvc;
using OnLineShop2026.Data;
using System.Diagnostics;
using WriterApp.Models;

namespace WriterApp.Controllers
{
    public class HomeController : Controller
    {
        public Guid MainId;
        ICollectionsRepository collectionsRepository;

        public IActionResult Index()
        {
            if(MainId != Guid.Empty)
            {
                ViewBag.MainId = MainId;
            }

            var collections = collectionsRepository.GetAll();
            return View(collections);
        }

        public HomeController(ICollectionsRepository collectRep)
        {
            this.collectionsRepository = collectRep;
        }
        public IActionResult SetMain(Guid id)
        {
            MainId = id;
            return RedirectToAction("Index");
        }

        public IActionResult AddNew()
        {
            Controller.Json("Ничего");
            return View();
        }





        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
