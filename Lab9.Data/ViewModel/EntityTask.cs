using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lab9.Data.Mapping;

namespace Lab9.Data.ViewModel
{
    public class EntityTask<T, TView>
        where T : class
        where TView : ViewBase
    {
        private MyModel _model;
        private DbSet<T> set;

        public EntityTask()
        {
            Mapping.Mapping.Initialize();
            _model = new MyModel();
            set = _model.Set<T>();
        }

        public bool Update(TView instance)
        {
            try
            {
                var DInstance = Mapper.Map<TView, T>(instance);
                var prevInstance = (T)set.Find(instance.GetId());
                foreach (var property in typeof(T).GetProperties())
                    property.SetValue(prevInstance, property.GetValue(DInstance));
                Save();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }

        public bool Add(TView instance)
        {
            try
            {
                var DInstance = Mapper.Map<TView, T>(instance);
                set.Add(DInstance);
                Save();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool Remove(int id)
        {
            try
            {
                var prevInstance = (T)set.Find(id);
                set.Remove(prevInstance);
                Save();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        private T GetById(int id)
        {
            return (T)set.Find(id);
        }

        private void Save()
        {
            _model.SaveChanges();
            set = _model.Set<T>();
        }

        public IEnumerable<TView> GetAll()
        {
            return Mapper.Map<DbSet<T>, IEnumerable<TView>>(set);
        }

        public TView Get(int id)
        {
            return Mapper.Map<T, TView>(GetById(id));
        }
    }
}
