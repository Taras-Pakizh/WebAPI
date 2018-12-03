using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lab9.Data;
using Lab9.Data.ViewModel;

namespace Lab9.Services
{
    public abstract class IService<T, TView> 
        where T : class
        where TView : ViewBase
    {
        protected EntityTask<T, TView> entity;

        public bool Update(TView view)
        {
            return entity.Update(view);
        }

        public bool Remove(int id)
        {
            return entity.Remove(id);
        }

        public bool Add(TView view)
        {
            return entity.Add(view);
        }

        public IEnumerable<TView> GetAll()
        {
            return entity.GetAll();
        }

        public TView GetById(int id)
        {
            return entity.Get(id);
        }
    }
}
