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
    public class HastaManager : IService<Hasta>
    {
        GenericRepository<Hasta> _Hasta = new GenericRepository<Hasta>();
        public void Add(Hasta entity)
        {
            _Hasta.Insert(entity);
        }

        public void Delete(Hasta entity)
        {
            _Hasta.Delete(entity);
        }

        public Hasta GetById(int id)
        {
            return _Hasta.Get(x => x.HastaId == id);
        }

        public List<Hasta> List()
        {
            return _Hasta.List();
        }

        public List<Hasta> List(Expression<Func<Hasta, bool>> filter)
        {
            return _Hasta.List();
        }

        public void Update(Hasta entity)
        {
            _Hasta.Update(entity);
        }
    }
}
