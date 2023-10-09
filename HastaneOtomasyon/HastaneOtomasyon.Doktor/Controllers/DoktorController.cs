using BusinessLayer.Concrate;
using DataLayer;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using static HastaneOtomasyon.Doktor.Controllers.HomeController;

namespace HastaneOtomasyon.Doktor.Controllers
{
    public class DoktorController : Controller
    {
        Context db = new Context();
        Anasayfa ana = new Anasayfa();
        Recete _recete;
        ReceteManager _receteler = new ReceteManager();

        RandevuViewModel _randevu;

        public List<RandevuViewModel> GetCustomRandevular()
        {
            int id = GlobalDeğişkenler.GirisId;
            var customRandevular = from r in db.tbl_Randevu
                                   join d in db.tbl_Doktorlar on r.DoktorId equals d.DoktorId
                                   join h in db.tbl_Hastalar on r.Hasta equals h.HastaId
                                   where d.DoktorId == id
                                   select new RandevuViewModel
                                   {
                                       RandevuId = r.RandevuId,
                                       HastaId = h.HastaId,
                                       Saat = r.Saat,
                                       Doktor = d.DoktorId,
                                       HastaAdiSoyadi = h.HastaAdi + ' ' + h.HastaSoyadi,
                                       DoktorAdiSoyadi = d.DoktorAdi + ' ' + d.DoktorSoyadi
                                   };

            return customRandevular.ToList();
        }
        public IActionResult Index()
        {
            int id = GlobalDeğişkenler.GirisId;
            ViewBag.isim = db.tbl_Doktorlar.FirstOrDefault(x => x.DoktorId == id).DoktorAdi;
            ViewBag.soyisim = db.tbl_Doktorlar.FirstOrDefault(x => x.DoktorId == id).DoktorSoyadi;
            var customRandevular = GetCustomRandevular();
            return View(customRandevular);
        }
        public IActionResult Bilgi(int id)
        {
            ViewBag.bilgi = id;
            var result = db.tbl_Hastalar.Where(x=>x.HastaId == id).ToList();
            ViewBag.adi = db.tbl_Hastalar.FirstOrDefault(x => x.HastaId == id).HastaAdi;
            ViewBag.soyadi = db.tbl_Hastalar.FirstOrDefault(x => x.HastaId == id).HastaSoyadi;

            return View(result);
        }
        [HttpGet]
        public IActionResult Recete(int id)
        {
            ViewBag.recete = id;    
            return View();
        }
        [HttpPost]
        public IActionResult Recete(Recete rec, int id)
        {
            rec.HastaId = id;
            _receteler.Add(rec);
            return RedirectToAction("Index");
        }
        public IActionResult VarolanRecete(int id)
        {
            var result = db.tbl_Recete.Where(x => x.HastaId == id).OrderByDescending(x=>x.ReceteId).ToList();
            return View(result);
        }
    }
}
