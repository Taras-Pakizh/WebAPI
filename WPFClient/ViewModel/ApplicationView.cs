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
                    Employees = await new GetController("d").Get<EmployeeView>("Employee");
                    break;
                case 1:
                    Positions = await new GetController("d").Get<PositionView>("Position");
                    break;
                case 2:
                    Departments = await new GetController("d").Get<DepartmentView>("Department");
                    break;
                case 3:
                    EmployeeOrders = await new GetController("d").Get<EmployeeOrderView>("EmployeeOrder");
                    break;
                case 4:
                    OrderTypes = await new GetController("d").Get<OrderTypeView>("OrderType");
                    break;
            }
        }

        private async void _Add(object obj)
        {
            bool result;
            switch (SelectedTable)
            {
                case 0:
                    var employee = (EmployeeView)obj;
                    employee.employeeID = Employees.Max(x => x.employeeID) + 1;
                    result = await AddController.Add("Employee", employee);
                    if (result) _Get(null);
                    break;
                case 1:
                    var position = (PositionView)obj;
                    position.positionID = Positions.Max(x => x.positionID) + 1;
                    result = await AddController.Add("Position", position);
                    if (result) _Get(null);
                    break;
                case 2:
                    var department = (DepartmentView)obj;
                    department.departmentID = Departments.Max(x => x.departmentID) + 1;
                    result = await AddController.Add("Department", department);
                    if (result) _Get(null);
                    break;
                case 3:
                    var eorder = (EmployeeOrderView)obj;
                    eorder.orderID = EmployeeOrders.Max(x => x.orderID) + 1;
                    result = await AddController.Add("EmployeeOrder", eorder);
                    if (result) _Get(null);
                    break;
                case 4:
                    var order = (OrderTypeView)obj;
                    order.orderTypeID = OrderTypes.Max(x => x.orderTypeID) + 1;
                    result = await AddController.Add("OrderType", order);
                    if (result) _Get(null);
                    break;
            }
        }

        private async void _Update(object obj)
        {
            bool result;
            switch (SelectedTable)
            {
                case 0:
                    var employee = (EmployeeView)obj;
                    result = await UpdateController.Update("Employee", employee);
                    if (result) _Get(null);
                    break;
                case 1:
                    var position = (PositionView)obj;
                    result = await UpdateController.Update("Position", position);
                    if (result) _Get(null);
                    break;
                case 2:
                    var department = (DepartmentView)obj;
                    result = await UpdateController.Update("Department", department);
                    if (result) _Get(null);
                    break;
                case 3:
                    var eorder = (EmployeeOrderView)obj;
                    result = await UpdateController.Update("EmployeeOrder", eorder);
                    if (result) _Get(null);
                    break;
                case 4:
                    var order = (OrderTypeView)obj;
                    result = await UpdateController.Update("OrderType", order);
                    if (result) _Get(null);
                    break;
            }
        }

        private async void _Delete(object obj)
        {
            bool result;
            switch (SelectedTable)
            {
                case 0:
                    var id = (int)obj;
                    result = await DeleteController.Delete("Employee", id);
                    if (result) _Get(null);
                    break;
                case 1:
                    var idd = (int)obj;
                    result = await DeleteController.Delete("Position", idd);
                    if (result) _Get(null);
                    break;
                case 2:
                    var department = (int)obj;
                    result = await DeleteController.Delete("Department", department);
                    if (result) _Get(null);
                    break;
                case 3:
                    var iddd = (int)obj;
                    result = await DeleteController.Delete("EmployeeOrder", iddd);
                    if (result) _Get(null);
                    break;
                case 4:
                    var last = (int)obj;
                    result = await DeleteController.Delete("OrderType", last);
                    if (result) _Get(null);
                    break;
            }
        }

        #endregion
    }
}
