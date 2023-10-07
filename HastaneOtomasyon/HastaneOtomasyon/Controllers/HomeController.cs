using BusinessLayer.Concrate;
using DataLayer;
using EntityLayer;
using HastaneOtomasyon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HastaneOtomasyon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Context db = new Context();
        Saatler _saat;
        SaatlerManager _saatler = new SaatlerManager();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Saatler()
        {
            var result = db.tbl_Saatler.ToList();
            return View(result);
        }
       public IActionResult SaatSil(int id)
        {
            _saat = _saatler.GetById(id);
            _saatler.Delete(_saat);

            return RedirectToAction("Saatler");
        }
        public IActionResult SaatKaydet(Saatler Saat)
        {
            _saatler.Add(Saat);
            return RedirectToAction("Saatler");
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