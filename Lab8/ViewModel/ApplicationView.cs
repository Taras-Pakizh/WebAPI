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

        public ApplicationView()
        {
            _model = new MyModel();

            string connection = ConfigurationManager.ConnectionStrings["MyModel"].ToString();

            _linqContext = new DataContext(connection);
            Table<Department> dep = _linqContext.GetTable<Department>();

            var ado = new ADOTask<Department>(connection);
            var departments = ado.All();


            var config = Mapping.Mapping.CreateMapper_Position_to_View();
            _positions = config.Map<IEnumerable<Position>, ObservableCollection<PositionView>>(_model.Positions);

            config = Mapping.Mapping.CreateMapper_Employee_to_View();
            _employees = config.Map<IEnumerable<Employee>, ObservableCollection<EmployeeView>>(_model.Employees);

            //config = Mapping.Mapping.CreateMapper_Department_to_View();
            //_departments = config.Map<IEnumerable<Department>, ObservableCollection<DepartmentView>>(dep);

            config = Mapping.Mapping.CreateMapper_Department_to_View();
            _departments = config.Map<IEnumerable<Department>, ObservableCollection<DepartmentView>>(_model.Departments);

            config = Mapping.Mapping.CreateMapper_OrderType_to_View();
            _orders = config.Map<IEnumerable<OrderType>, ObservableCollection<OrderTypeView>>(_model.OrderTypes);

            config = Mapping.Mapping.CreateMapper_EmployeeOrder_to_View();
            _employeeOrders = config.Map<IEnumerable<EmployeeOrder>, ObservableCollection<EmployeeOrderView>>(_model.EmployeeOrders);
        }

        #region Properties
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

        #endregion
    }
}
