using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

using Lab8.Mapping;
using AutoMapper;
using System.Windows.Input;

using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Configuration;

namespace Lab8.ViewModel
{
    public class ApplicationView:ViewBase
    {
        private MyModel _model;
        private DataContext _linqContext;
        private ADOTask<Department> _AdoTask;
        private string _connection;

        public ApplicationView()
        {
            _model = new MyModel();
            Mapping.Mapping.Initialize();
            _connection = ConfigurationManager.ConnectionStrings["MyModel"].ToString();

            _linqContext = new DataContext(_connection);
            Table<Department> dep = _linqContext.GetTable<Department>();

            _AdoTask = new ADOTask<Department>(_connection);
            var departments = _AdoTask.All();


            var config = Mapping.Mapping.CreateMapper_Position_to_View();
            _positions = config.Map<IEnumerable<Position>, ObservableCollection<PositionView>>(_model.Positions);

            config = Mapping.Mapping.CreateMapper_Employee_to_View();
            _employees = config.Map<IEnumerable<Employee>, ObservableCollection<EmployeeView>>(_model.Employees);

            config = Mapping.Mapping.CreateMapper_Department_to_View();
            _departments = config.Map<IEnumerable<Department>, ObservableCollection<DepartmentView>>(_model.Departments);

            config = Mapping.Mapping.CreateMapper_OrderType_to_View();
            _orders = config.Map<IEnumerable<OrderType>, ObservableCollection<OrderTypeView>>(_model.OrderTypes);

            config = Mapping.Mapping.CreateMapper_EmployeeOrder_to_View();
            _employeeOrders = config.Map<IEnumerable<EmployeeOrder>, ObservableCollection<EmployeeOrderView>>(_model.EmployeeOrders);
        }

        private void _GetDepartments()
        {
            switch (Technology)
            {
                case 0:
                    Departments = Mapper.Map<IEnumerable<Department>, ObservableCollection<DepartmentView>>(_model.Departments);
                    break;
                case 1:
                    Departments = Mapper.Map<IEnumerable<Department>, ObservableCollection<DepartmentView>>(_AdoTask.All());
                    break;
                case 2:
                    Departments = Mapper.Map<IEnumerable<Department>, ObservableCollection<DepartmentView>>(_linqContext.GetTable<Department>());
                    break;
            }
        }

        #region Properties

        private int _count;
        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        private int _technology;
        public int Technology
        {
            get { return _technology; }
            set
            {
                _technology = value;
                _GetDepartments();
                OnPropertyChanged(nameof(Technology));
            }
        }

        private ObservableCollection<EmployeeView> _employees;
        public ObservableCollection<EmployeeView> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        private ObservableCollection<PositionView> _positions;
        public ObservableCollection<PositionView> Positions
        {
            get { return _positions; }
            set
            {
                _positions = value;
                OnPropertyChanged(nameof(Positions));
            }
        }

        private ObservableCollection<OrderTypeView> _orders;
        public ObservableCollection<OrderTypeView> OrderTypes
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(OrderTypes));
            }
        }

        private ObservableCollection<DepartmentView> _departments;
        public ObservableCollection<DepartmentView> Departments
        {
            get { return _departments; }
            set
            {
                _departments = value;
                OnPropertyChanged(nameof(Departments));
            }
        }

        private ObservableCollection<EmployeeOrderView> _employeeOrders;
        public ObservableCollection<EmployeeOrderView> EmployeeOrders
        {
            get { return _employeeOrders; }
            set
            {
                _employeeOrders = value;
                OnPropertyChanged(nameof(EmployeeOrders));
            }
        }
        #endregion

        #region Commands

        private Command _entity;
        public ICommand UseEntity
        {
            get
            {
                if (_entity != null)
                    return _entity;
                _entity = new Command(_UseEntityTask);
                return _entity;
            }
        }

        private Command _linqToSql;
        public ICommand UseLinq
        {
            get
            {
                if (_linqToSql != null)
                    return _linqToSql;
                _linqToSql = new Command(_UseLinq);
                return _linqToSql;
            }
        }

        private Command _ado;
        public ICommand UseAdo
        {
            get
            {
                if (_ado != null)
                    return _ado;
                _ado = new Command(_UseAdo);
                return _ado;
                
            }
        }

        private Command _group;
        public ICommand Group
        {
            get
            {
                if (_group != null)
                    return _group;
                _group = new Command(_UseGroup);
                return _group;
            }
        }

        #endregion

        #region CommandExecution

        private void _UseEntityTask(object obj)
        {
            Mapping.Mapping.Initialize();

            ViewBase view; IModelTask Task = null;
            var parameter = obj as ModifyParameter;
            if (parameter != null)
                view = parameter.view;
            else view = (ViewBase)obj;

            if(view is DepartmentView)
            {
                Task = new EntityTask<Department, DepartmentView>(_model, this);
            }
            else if(view is PositionView)
            {
                Task = new EntityTask<Position, PositionView>(_model, this);
            }
            else if(view is EmployeeOrderView)
            {
                Task = new EntityTask<EmployeeOrder, EmployeeOrderView>(_model, this);
            }
            else if(view is EmployeeView)
            {
                Task = new EntityTask<Employee, EmployeeView>(_model, this);
            }
            else if(view is OrderTypeView)
            {
                Task = new EntityTask<OrderType, OrderTypeView>(_model, this);
            }

            Task.Execute(obj);
        }

        private void _UseLinq(object obj)
        {
            var Task = new LinqTask(this, _linqContext);
            Task.Execute(obj);
        }

        private void _UseAdo(object obj)
        {
            Department entity;
            var parameter = obj as ModifyParameter;
            if (parameter != null)
                entity = Mapper.Map<DepartmentView, Department>((DepartmentView)parameter.view);
            else entity = Mapper.Map<DepartmentView, Department>((DepartmentView)obj);

            if (parameter == null)
                _AdoTask.Delete(entity);
            else if (parameter.Add)
                _AdoTask.Insert(entity);
            else if (parameter.Update)
                _AdoTask.Update(entity);
            _GetDepartments();
        }

        private void _UseGroup(object obj)
        {
            if (((int)obj) == -1)
                return;
            var set = _model.Set<Employee>();
            var groups = set.GroupBy(s => s.department).Select(x => new
            {
                department = x.Key,
                Count = x.Count()
            }).ToList();
            if (groups.Count <= (int)obj)
                Count = 0;
            else Count = groups[(int)obj].Count;
        }

        #endregion
    }
}
