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
                                       Saat = r.Saat,
                                       Doktor = d.DoktorId,
                                       HastaAdiSoyadi = h.HastaAdi + ' ' + h.HastaSoyadi,
                                       DoktorAdiSoyadi = d.DoktorAdi + ' ' + d.DoktorSoyadi
                                   };

            return customRandevular.ToList();
        }
        public IActionResult Index()
        {
            
            //ana.Doktorlar = db.tbl_Doktorlar.Where(x => x.DoktorId == id).ToList();

            //return View(ana);

            var customRandevular = GetCustomRandevular();
            return View(customRandevular);


        }
    }
}
