using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Lab9.Data.ViewModel;
using WPFClient.RequestController;

namespace WPFClient.ViewModel
{
    class ApplicationView:BaseView
    {

        public ApplicationView()
        {

        }

        #region Properties

        private int _selectedTable;
        public int SelectedTable
        {
            get { return _selectedTable; }
            set
            {
                _selectedTable = value;
                OnPropertyChanged(nameof(SelectedTable));
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

        private ObservableCollection<OrderTypeView> _orderTypes;
        public ObservableCollection<OrderTypeView> OrderTypes
        {
            get { return _orderTypes; }
            set
            {
                _orderTypes = value;
                OnPropertyChanged(nameof(OrderTypes));
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

        private Command _get;
        public ICommand Get
        {
            get
            {
                if (_get != null)
                    return _get;
                _get = new Command(_Get);
                return _get;
            }
        }

        private Command _add;
        public ICommand Add
        {
            get
            {
                if (_add != null)
                    return _add;
                _add = new Command(_Add);
                return _add;
            }
        }

        private Command _update;
        public ICommand Update
        {
            get
            {
                if (_update != null)
                    return _update;
                _update = new Command(_Update);
                return _update;
            }
        }

        private Command _delete;
        public ICommand Delete
        {
            get
            {
                if (_delete != null)
                    return _delete;
                _delete = new Command(_Delete);
                return _delete;
            }
        }

        #endregion

        #region CommandExecution

        private async void _Get(object obj)
        {
            switch (SelectedTable)
            {
                case 0:
                    var employees = (IEnumerable<EmployeeView>)await GetController.GetAll<EmployeeView>("Employee");
                    var employeeView = new ObservableCollection<EmployeeView>();
                    foreach(var item in employees)
                    {
                        employeeView.Add(new EmployeeView()
                        {
                            employeeID = item.employeeID,
                            firstname = item.firstname,
                            lastname = item.lastname,
                            birthday = item.birthday,
                            gender = item.gender,
                            position = item.position
                        });
                    }
                    Employees = employeeView;
                    break;
                case 1:
                    var positions = (IEnumerable<PositionView>)await GetController.GetAll<PositionView>("Position");
                    var positionView = new ObservableCollection<PositionView>();
                    foreach(var item in positions)
                    {
                        positionView.Add(new PositionView()
                        {
                            positionID = item.positionID,
                            positionName = item.positionName,
                            salary = item.salary
                        });
                    }
                    Positions = positionView;
                    break;
                case 2:
                    var departments = (IEnumerable<DepartmentView>)await GetController.GetAll<DepartmentView>("Department");
                    var views = new ObservableCollection<DepartmentView>();
                    foreach (var item in departments)
                    {
                        views.Add(new DepartmentView()
                        {
                            departmentID = item.departmentID,
                            dname = item.dname
                        });
                    }
                    Departments = views;
                    break;
                case 3:
                    var employeeOrders = (IEnumerable<EmployeeOrderView>)await GetController.GetAll<EmployeeOrderView>("EmployeeOrder");
                    var employeeOrderView = new ObservableCollection<EmployeeOrderView>();
                    foreach(var item in employeeOrders)
                    {
                        employeeOrderView.Add(new EmployeeOrderView()
                        {
                            orderID = item.orderID,
                            orderDate = item.orderDate,
                            orderDescription = item.orderDescription,
                            Employee = item.Employee,
                            orderType = item.orderType
                        });
                    }
                    EmployeeOrders = employeeOrderView;
                    break;
                case 4:
                    var orders = (IEnumerable<OrderTypeView>)await GetController.GetAll<OrderTypeView>("OrderType");
                    var orderView = new ObservableCollection<OrderTypeView>();
                    foreach(var item in orders)
                    {
                        orderView.Add(new OrderTypeView()
                        {
                            orderTypeID = item.orderTypeID,
                            orderName = item.orderName
                        });
                    }
                    OrderTypes = orderView;
                    break;
            }
        }

        private async void _Add(object obj)
        {

        }

        private async void _Update(object obj)
        {

        }

        private async void _Delete(object obj)
        {

        }

        #endregion
    }
}
