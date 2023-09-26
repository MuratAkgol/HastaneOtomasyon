using BusinessLayer.Concrate;
using DataLayer;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace HastaneOtomasyon.Admin.Controllers
{
    public class AdminController : Controller
    {
        Context db = new Context();
        Polikinlik _polikinlik;
        PoliklinikManager _poliklinikler = new PoliklinikManager();

        Doktor _doktor;
        DoktorManager _doktorlar = new DoktorManager();

        Hasta _hasta;
        HastaManager _hastalar = new HastaManager();
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult PolKaydet()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PolKaydet(Polikinlik pol)
        {
            _poliklinikler.Add(pol);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DrKaydet()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DrKaydet(Doktor dr)
        {
            _doktorlar.Add(dr);
            return RedirectToAction("Index");
        }
    }
}
