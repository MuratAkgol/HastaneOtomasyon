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
    public class ReceteManager: IService<Recete>
    {
        GenericRepository<Recete> _Recete = new GenericRepository<Recete>();
        public void Add(Recete entity)
        {
            _Recete.Insert(entity);
        }

        public void Delete(Recete entity)
        {
            _Recete.Delete(entity);
        }

        public Recete GetById(int id)
        {
            return _Recete.Get(x => x.ReceteId == id);
        }

        public List<Recete> List()
        {
            return _Recete.List();
        }

        public List<Recete> List(Expression<Func<Recete, bool>> filter)
        {
            return _Recete.List();
        }

        public void Update(Recete entity)
        {
            _Recete.Update(entity);
        }
    }
}
