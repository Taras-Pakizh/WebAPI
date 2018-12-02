using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Linq;
using System.Configuration;
using System.Collections.ObjectModel;

namespace Lab8.ViewModel
{
    public class LinqTask:IModelTask
    {
        private ApplicationView _view;
        private DataContext _model;

        public LinqTask(ApplicationView view, DataContext context)
        {
            _view = view;
            _model = context;
        }

        public void Execute(object obj)
        {
            ModifyParameter parameter = obj as ModifyParameter;
            if (parameter == null)
            {
                if (obj is DepartmentView)
                {
                    DeleteDepartment((DepartmentView)obj);
                }
                else if (obj is EmployeeView)
                {

                }
                else if (obj is EmployeeOrderView)
                {

                }
                else if (obj is PositionView)
                {

                }
                else if (obj is OrderTypeView)
                {

                }
            }
            else if (parameter.Add)
            {
                if (parameter.view is DepartmentView)
                {
                    AddDepartment(parameter);
                }
                else if (parameter.view is EmployeeView)
                {

                }
                else if (parameter.view is EmployeeOrderView)
                {

                }
                else if (parameter.view is PositionView)
                {

                }
                else if (parameter.view is OrderTypeView)
                {

                }
            }
            else if (parameter.Update)
            {
                if (parameter.view is DepartmentView)
                {
                    UpdateDepartment(parameter);
                }
                else if (parameter.view is EmployeeView)
                {

                }
                else if (parameter.view is EmployeeOrderView)
                {

                }
                else if (parameter.view is PositionView)
                {

                }
                else if (parameter.view is OrderTypeView)
                {

                }
            }
        }

        private void DeleteDepartment(DepartmentView _department)
        {
            if (_department == null)
                return;
            var config = Mapping.Mapping.CreateMapper_View_to_Department();
            var itemToDelete = config.Map<DepartmentView, Department>(_department);

            itemToDelete = _model.GetTable<Department>().Single(x => x.departmentID == itemToDelete.departmentID);
            _model.GetTable<Department>().DeleteOnSubmit(itemToDelete);
            _model.SubmitChanges();

            config = Mapping.Mapping.CreateMapper_Department_to_View();
            _view.Departments = config.Map<IEnumerable<Department>, ObservableCollection<DepartmentView>>(_model.GetTable<Department>());
        }

        private void UpdateDepartment(ModifyParameter parameter)
        {
            var config = Mapping.Mapping.CreateMapper_View_to_Department();
            var newItem = config.Map<DepartmentView, Department>((DepartmentView)parameter.view);

            var prevItem = _model.GetTable<Department>().Where(x => x.departmentID == newItem.departmentID).FirstOrDefault();
            prevItem.dname = newItem.dname;
            _model.SubmitChanges();

            config = Mapping.Mapping.CreateMapper_Department_to_View();
            _view.Departments = config.Map<IEnumerable<Department>, ObservableCollection<DepartmentView>>(_model.GetTable<Department>());
        }

        private void AddDepartment(ModifyParameter parameter)
        {
            var config = Mapping.Mapping.CreateMapper_View_to_Department();
            var newItem = config.Map<DepartmentView, Department>((DepartmentView)parameter.view);

            newItem.departmentID = _model.GetTable<Department>().Max(x => x.departmentID) + 1;
            _model.GetTable<Department>().InsertOnSubmit(newItem);
            _model.SubmitChanges();

            config = Mapping.Mapping.CreateMapper_Department_to_View();
            _view.Departments = config.Map<IEnumerable<Department>, ObservableCollection<DepartmentView>>(_model.GetTable<Department>());
        }
    }
}
