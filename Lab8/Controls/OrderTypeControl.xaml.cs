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
    /// Логика взаимодействия для OrderTypeControl.xaml
    /// </summary>
    public partial class OrderTypeControl : UserControl
    {
        public OrderTypeControl()
        {
            InitializeComponent();
            SubVisibility = Visibility.Visible;
        }

        public static readonly DependencyProperty SubVisibilityProperty;
        public Visibility SubVisibility
        {
            get { return (Visibility)GetValue(SubVisibilityProperty); }
            set { SetValue(SubVisibilityProperty, value); }
        }

        public static readonly DependencyProperty EmployeesOrdersProperty;
        public ICollection<EmployeeOrderView> EmployeeOrders
        {
            get { return (ICollection<EmployeeOrderView>)GetValue(EmployeesOrdersProperty); }
            set { SetValue(EmployeesOrdersProperty, value); }
        }

        static OrderTypeControl()
        {
            EmployeesOrdersProperty = DependencyProperty.Register(nameof(EmployeeOrders),
                typeof(ICollection<EmployeeOrderView>), typeof(OrderTypeControl));
            SubVisibilityProperty = DependencyProperty.Register(nameof(SubVisibility),
                typeof(Visibility), typeof(OrderTypeControl));
        }

        private void MyGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (MyGrid.SelectedIndex == -1)
                return;
            var _orderType = (OrderTypeView)MyGrid.SelectedItem;
            EmployeeOrders = _orderType.EmployeeOrders;
        }
    }
}
