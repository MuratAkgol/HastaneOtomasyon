using DataLayer;
using EntityLayer;
using HastaneOtomasyon.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HastaneOtomasyon.UI.Controllers
{
    public class HomeController : Controller
    {
        Context db = new Context();
        Anasayfa ana = new Anasayfa();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ana.Doktorlar = db.tbl_Doktorlar.ToList();
            ana.Pol = db.tbl_Polikinlikler.ToList();
            return View(ana);
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