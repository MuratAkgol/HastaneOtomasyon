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
    public class PoliklinikManager : IService<Polikinlik>
    {
        GenericRepository<Polikinlik> _poliklinik = new GenericRepository<Polikinlik>();
        public void Add(Polikinlik entity)
        {
            _poliklinik.Insert(entity);
        }

        public void Delete(Polikinlik entity)
        {
            _poliklinik.Delete(entity);
        }

        public Polikinlik GetById(int id)
        {
            return _poliklinik.Get(x => x.PolikinlikId == id);
        }

        public List<Polikinlik> List()
        {
            return _poliklinik.List();
        }

        public List<Polikinlik> List(Expression<Func<Polikinlik, bool>> filter)
        {
            return _poliklinik.List();
        }

        public void Update(Polikinlik entity)
        {
            _poliklinik.Update(entity);
        }
    }
}
