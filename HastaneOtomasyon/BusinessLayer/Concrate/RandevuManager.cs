using BusinessLayer.Abstract;
using DataLayer.GenericRepository;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class RandevuManager : IService<Randevu>
    {
        GenericRepository<Randevu> _Randevu = new GenericRepository<Randevu>();
        public void Add(Randevu entity)
        {
            _Randevu.Insert(entity);
        }

        public void Delete(Randevu entity)
        {
            _Randevu.Delete(entity);
        }

        public Randevu GetById(int id)
        {
            return _Randevu.Get(x => x.RandevuId == id);
        }

        public List<Randevu> List()
        {
            return _Randevu.List();
        }

        public List<Randevu> List(Expression<Func<Randevu, bool>> filter)
        {
            return _Randevu.List();
        }

        public void Update(Randevu entity)
        {
            _Randevu.Update(entity);
        }
    }
}
