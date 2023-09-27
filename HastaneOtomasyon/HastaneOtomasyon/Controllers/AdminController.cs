using BusinessLayer.Concrate;
using DataLayer;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HastaneOtomasyon.Admin.Controllers
{
    public class AdminController : Controller
    {
        Context db = new Context();
        Polikinlik _polikinlik;
        PoliklinikManager _poliklinikler = new PoliklinikManager();

        Doktor _doktor;
        DoktorManager _doktorlar = new DoktorManager();

        Anasayfa ana = new Anasayfa();

        Hasta _hasta;
        HastaManager _hastalar = new HastaManager();
        public IActionResult Index()
        {
            ana.Pol = db.tbl_Polikinlikler.ToList();
            ana.Doktorlar = db.tbl_Doktorlar.ToList();
            ana.Doktor2 = db.tbl_Doktorlar.Where(d => d != null).ToList();
            ana.Hasta = db.tbl_Hastalar.ToList();

            ana.Doktor2Gruplu = ana.Doktor2.GroupBy(d => d.PolikinlikId)
                                  .ToDictionary(group => group.Key, group => group.ToList());



            return View(ana);
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
            ana.Pol = db.tbl_Polikinlikler.ToList();
            return View(ana);
        }
        [HttpPost]
        public IActionResult DrKaydet(Doktor dr)
        {
            _doktorlar.Add(dr);
            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public IActionResult DrGuncelle(int id)
        {
            _doktor = _doktorlar.GetById(id);
            ana.Doktorlar = db.tbl_Doktorlar.Where(x => x.DoktorId == id).ToList();
            int drpolid = db.tbl_Doktorlar.FirstOrDefault(x => x.DoktorId == id).PolikinlikId;
            ana.Pol = db.tbl_Polikinlikler.ToList();
            ViewBag.pol = ana.Pol;
            return View(_doktor);
        }
        [HttpPost]
        public IActionResult DrGuncelle(Doktor dr)
        {
            _doktorlar.Update(dr);
            return RedirectToAction("Index");
        }
        public IActionResult DrSil(int id)
        {
            _doktor = _doktorlar.GetById(id);
            _doktorlar.Delete(_doktor);
            return RedirectToAction("Index");
        }
        public IActionResult PolSil(int id)
        {
            _polikinlik = _poliklinikler.GetById(id);
            _poliklinikler.Delete(_polikinlik);
            return RedirectToAction("Index");
        }
    }
}
