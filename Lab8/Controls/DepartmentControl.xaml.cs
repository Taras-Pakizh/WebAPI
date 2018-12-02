using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lab8.ViewModel;

namespace Lab8.Controls
{
    /// <summary>
    /// Логика взаимодействия для DepartmentControl.xaml
    /// </summary>
    public partial class DepartmentControl : UserControl
    {
        public static readonly DependencyProperty EmployeesProperty;
        public ICollection<EmployeeView> Employees
        {
            get { return (ICollection<EmployeeView>)GetValue(EmployeesProperty); }
            set { SetValue(EmployeesProperty, value); }
        }

        static DepartmentControl()
        {
            EmployeesProperty = DependencyProperty.Register(nameof(Employees),
                typeof(ICollection<EmployeeView>), typeof(DepartmentControl));
        }

        public DepartmentControl()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (MyGrig.SelectedIndex == -1)
                return;
            var _department = (DepartmentView)MyGrig.SelectedItem;
            Employees = _department.Employees;
        }
    }
}
