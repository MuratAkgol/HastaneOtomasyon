using BusinessLayer.Concrate;
using DataLayer;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace HastaneOtomasyon.UI.Controllers
{
    public class RandevuController : Controller
    {
        Context db = new Context();
        Anasayfa ana = new Anasayfa();
        Hasta _hasta;
        HastaManager _hastalar = new HastaManager();
        Randevu _randevu;
        RandevuManager _randevular = new RandevuManager();
        public IActionResult Index()
        {
            ana.Pol = db.tbl_Polikinlikler.ToList();
            ana.Doktorlar = db.tbl_Doktorlar.ToList();
            
            
            return View(ana);
        }
        
        public IActionResult SecilenPolDr(Polikinlik pol)
        {
            
            int id =pol.PolikinlikId;
            ana.Pol = db.tbl_Polikinlikler.ToList();
            ana.Doktorlar = db.tbl_Doktorlar.Where(x=>x.PolikinlikId == id).ToList();
            ana.Saat = db.tbl_Saatler.ToList();
            ana.Randevular = db.tbl_Randevu.ToList();
            return View(ana);
        }
        [HttpPost]
        public IActionResult RandevuOlustur(Hasta hasta, Randevu ran)
        {
            _hastalar.Add(hasta);
            ran.Hasta = hasta.HastaId;
            _randevular.Add(ran);
            return RedirectToAction("Index","Home");
        }
    }
}
