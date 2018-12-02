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

namespace Lab8.ViewModel
{
    public class ApplicationView:ViewBase
    {
        private MyModel _model;
        public ApplicationView()
        {
            _model = new MyModel();
            

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
        public ObservableCollection<OrderTypeView> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
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
    }
}
