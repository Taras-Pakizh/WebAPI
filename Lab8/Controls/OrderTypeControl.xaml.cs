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
        }

        private void MyGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }
    }
}
