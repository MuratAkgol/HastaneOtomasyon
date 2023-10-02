using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-PT4JT3A9; Database=HastaneOtomasyon; Trusted_Connection=true");
        }
        public DbSet<Doktor> tbl_Doktorlar { get; set; }
        public DbSet<Polikinlik> tbl_Polikinlikler { get; set; }
        public DbSet<Hasta> tbl_Hastalar{ get; set; }
        public DbSet<Saatler> tbl_Saatler { get; set; }
        public DbSet<Randevu> tbl_Randevu { get; set; }
    }
}
