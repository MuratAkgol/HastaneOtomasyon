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
    public class DoktorManager : IService<Doktor>
    {
        GenericRepository<Doktor> _doktor = new GenericRepository<Doktor>();
        public void Add(Doktor entity)
        {
            _doktor.Insert(entity);
        }

        public void Delete(Doktor entity)
        {
            _doktor.Delete(entity);
        }

        public Doktor GetById(int id)
        {
            return _doktor.Get(x => x.DoktorId == id);
        }

        public List<Doktor> List()
        {
            return _doktor.List();
        }

        public List<Doktor> List(Expression<Func<Doktor, bool>> filter)
        {
            return _doktor.List();
        }

        public void Update(Doktor entity)
        {
            _doktor.Update(entity);
        }
    }
}
