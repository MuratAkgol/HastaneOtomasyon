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
    public class SaatlerManager: IService<Saatler>
    {
        GenericRepository<Saatler> _Saatler = new GenericRepository<Saatler>();
        public void Add(Saatler entity)
        {
            _Saatler.Insert(entity);
        }

        public void Delete(Saatler entity)
        {
            _Saatler.Delete(entity);
        }

        public Saatler GetById(int id)
        {
            return _Saatler.Get(x => x.Id == id);
        }

        public List<Saatler> List()
        {
            return _Saatler.List();
        }

        public List<Saatler> List(Expression<Func<Saatler, bool>> filter)
        {
            return _Saatler.List();
        }

        public void Update(Saatler entity)
        {
            _Saatler.Update(entity);
        }
    }
}
