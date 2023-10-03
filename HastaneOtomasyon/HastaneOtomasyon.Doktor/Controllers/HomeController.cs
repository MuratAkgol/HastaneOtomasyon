using BusinessLayer.Concrate;
using DataLayer;
using HastaneOtomasyon.Doktor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HastaneOtomasyon.Doktor.Controllers
{
    public class HomeController : Controller
    {
        Context db = new Context();
        DoktorManager _doktorlar = new DoktorManager();
        EntityLayer.Doktor _doktor;
        private readonly ILogger<HomeController> _logger;

        public class GlobalDeğişkenler
        {
            public static int GirisId { get; set; }
        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(EntityLayer.Doktor dr)
        {
            var control = db.tbl_Doktorlar.SingleOrDefault(x => x.DoktorTc == dr.DoktorTc && x.DoktorSifre == dr.DoktorSifre);
            var id = db.tbl_Doktorlar.FirstOrDefault(x => x.DoktorTc == dr.DoktorSifre).DoktorId;
            if (control != null)
            {
                GlobalDeğişkenler.GirisId = id;
                return RedirectToAction("Index","Doktor");
            }
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