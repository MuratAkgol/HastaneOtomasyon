using DataLayer;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace HastaneOtomasyon.UI.Controllers
{
    public class RandevuController : Controller
    {
        Context db = new Context();
        Anasayfa ana = new Anasayfa();
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
            return View(ana);
        }

    }
}
