using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lab8.Mapping;

namespace Lab8.ViewModel
{
    public class EntityTask<T, TView>:IModelTask 
        where T : class 
        where TView : IIdable
    {
        private MyModel _model;
        private ApplicationView applicationView;
        private DbSet set;

        public EntityTask(MyModel model, ApplicationView view)
        {
            _model = model;
            applicationView = view;
            set = _model.Set<T>();
        }

        public void Execute(object obj)
        {
            var parameter = obj as ModifyParameter;
            if(parameter == null)
            {
                Remove((TView)obj);
                return;
            }
            if (parameter.Add)
            {
                object Obj = parameter.view;
                Add((TView)Obj);
            }
            else if (parameter.Update)
            {
                object Obj = parameter.view;
                Update((TView)Obj);
            }

            #region Prev
            //ModifyParameter parameter = obj as ModifyParameter;
            //if(parameter == null)
            //{
            //    if (obj is DepartmentView)
            //    {
            //        DeleteDepartment((DepartmentView)obj);
            //    }
            //    else if (obj is EmployeeView)
            //    {

            //    }
            //    else if (obj is EmployeeOrderView)
            //    {

            //    }
            //    else if (obj is PositionView)
            //    {

            //    }
            //    else if (obj is OrderTypeView)
            //    {

            //    }
            //}
            //else if (parameter.Add)
            //{
            //    if(parameter.view is DepartmentView)
            //    {
            //        AddDepartment(parameter);
            //    }
            //    else if(parameter.view is EmployeeView)
            //    {

            //    }
            //    else if(parameter.view is EmployeeOrderView)
            //    {

            //    }
            //    else if(parameter.view is PositionView)
            //    {

            //    }
            //    else if(parameter.view is OrderTypeView)
            //    {

            //    }
            //}
            //else if (parameter.Update)
            //{
            //    if (parameter.view is DepartmentView)
            //    {
            //        UpdateDepartment(parameter);
            //    }
            //    else if (parameter.view is EmployeeView)
            //    {

            //    }
            //    else if (parameter.view is EmployeeOrderView)
            //    {

            //    }
            //    else if (parameter.view is PositionView)
            //    {

            //    }
            //    else if (parameter.view is OrderTypeView)
            //    {

            //    }
            //}
            #endregion
        }

        public void Update(TView instance)
        {
            var DInstance = Mapper.Map<TView, T>(instance);
            var prevInstance = (T)set.Find(instance.GetId());

            foreach(var property in typeof(T).GetProperties())
            {
                property.SetValue(prevInstance, property.GetValue(DInstance));
            }

            _model.SaveChanges();
            set = _model.Set<T>();
            RefreshProperty();
        }

        public void Add(TView instance)
        {
            var DInstance = Mapper.Map<TView, T>(instance);
            set.Add(DInstance);
            _model.SaveChanges();
            set = _model.Set<T>();
            RefreshProperty();
        }

        public void Remove(TView instance)
        {
            var prevInstance = (T)set.Find(instance.GetId());
            set.Remove(prevInstance);
            _model.SaveChanges();
            set = _model.Set<T>();
            RefreshProperty();
        }

        private void RefreshProperty()
        {
            var newPropertyValue = Mapper.Map<IEnumerable<T>, ObservableCollection<TView>>((IEnumerable<T>)set);
            var Property = typeof(ApplicationView).GetProperty(typeof(T).Name + "s");
            Property.SetValue(applicationView, newPropertyValue);
        }

        private T GetById(int id)
        {
            return (T)set.Find(id);
        }

        private void UpdateDepartment(ModifyParameter parameter)
        {
            var config = Mapping.Mapping.CreateMapper_View_to_Department();
            var newItem = config.Map<DepartmentView, Department>((DepartmentView)parameter.view);
            var prevItem = _model.Departments.Where(x => x.departmentID == newItem.departmentID).FirstOrDefault();
            prevItem.dname = newItem.dname;
            prevItem.Employees = newItem.Employees;
            _model.SaveChanges();
            config = Mapping.Mapping.CreateMapper_Department_to_View();
            applicationView.Departments = config.Map<IEnumerable<Department>, ObservableCollection<DepartmentView>>(_model.Departments);
        }

        private void AddDepartment(ModifyParameter parameter)
        {
            var config = Mapping.Mapping.CreateMapper_View_to_Department();
            var newItem = config.Map<DepartmentView, Department>((DepartmentView)parameter.view);
            newItem.departmentID = _model.Departments.Max(x => x.departmentID) + 1;
            _model.Departments.Add(newItem);
            _model.SaveChanges();
            config = Mapping.Mapping.CreateMapper_Department_to_View();
            applicationView.Departments = config.Map<IEnumerable<Department>, ObservableCollection<DepartmentView>>(_model.Departments);
        }

        private void DeleteDepartment(DepartmentView _department)
        {
            if (_department == null)
                return;
            var config = Mapping.Mapping.CreateMapper_View_to_Department();
            var itemToDelete = config.Map<DepartmentView, Department>(_department);

            itemToDelete = _model.Departments.Where(x => x.departmentID == itemToDelete.departmentID).FirstOrDefault();
            _model.Departments.Remove(itemToDelete);
            _model.SaveChanges();

            config = Mapping.Mapping.CreateMapper_Department_to_View();
            applicationView.Departments = config.Map<IEnumerable<Department>, ObservableCollection<DepartmentView>>(_model.Departments);
        }
    }
}
