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
    /// Логика взаимодействия для PositionControl.xaml
    /// </summary>
    public partial class PositionControl : UserControl
    {
        public PositionControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty EmployeesProperty;
        public ICollection<EmployeeView> Employees
        {
            get { return (ICollection<EmployeeView>)GetValue(EmployeesProperty); }
            set { SetValue(EmployeesProperty, value); }
        }

        static PositionControl()
        {
            EmployeesProperty = DependencyProperty.Register(nameof(Employees),
                typeof(ICollection<EmployeeView>), typeof(PositionControl));
        }

        private void MyGrig_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (MyGrig.SelectedIndex == -1)
                return;
            var _position = (PositionView)MyGrig.SelectedItem;
            Employees = _position.Employees;
        }
    }
}
