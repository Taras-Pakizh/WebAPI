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
using Lab9.Data.ViewModel;
using WPFClient.ViewModel;

namespace WPFClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = new DepartmentView();
            result.dname = dnamePost.Text;
            ((ApplicationView)DataContext).Add.Execute(result);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (DepartmentGrid.SelectedIndex == -1)
                return;
            var result = new DepartmentView();
            result.dname = dnamePut.Text;
            result.departmentID = ((DepartmentView)DepartmentGrid.SelectedItem).departmentID;
            ((ApplicationView)DataContext).Update.Execute(result);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (DepartmentGrid.SelectedIndex == -1)
                return;
            ((ApplicationView)DataContext).Delete.Execute(((DepartmentView)DepartmentGrid.SelectedItem).departmentID);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var result = new EmployeeView();
            result.firstname = firstnamePost.Text;
            result.lastname = lastnamePost.Text;
            ((ApplicationView)DataContext).Add.Execute(result);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (EmployeeGrid.SelectedIndex == -1)
                return;
            var result = new EmployeeView();
            result.firstname = firstnamePut.Text;
            result.lastname = lastnamePut.Text;
            result.employeeID = ((EmployeeView)EmployeeGrid.SelectedItem).employeeID;
            ((ApplicationView)DataContext).Update.Execute(result);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (EmployeeGrid.SelectedIndex == -1)
                return;
            ((ApplicationView)DataContext).Delete.Execute(((EmployeeView)EmployeeGrid.SelectedItem).employeeID);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var result = new PositionView();
            result.positionName = positionNamePost.Text;
            result.salary = Int32.Parse(salaryPost.Text);
            ((ApplicationView)DataContext).Add.Execute(result);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (PositionGrid.SelectedIndex == -1)
                return;
            var result = new PositionView();
            result.positionName = positionNamePut.Text;
            result.salary = Int32.Parse(salaryPut.Text);
            result.positionID = ((PositionView)PositionGrid.SelectedItem).positionID;
            ((ApplicationView)DataContext).Update.Execute(result);
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (PositionGrid.SelectedIndex == -1)
                return;
            ((ApplicationView)DataContext).Delete.Execute(((PositionView)PositionGrid.SelectedItem).positionID);
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            var result = new EmployeeOrderView();
            result.orderDescription = descriptionPost.Text;
            ((ApplicationView)DataContext).Add.Execute(result);
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            if (EmployeeOrderGrid.SelectedIndex == -1)
                return;
            var result = new EmployeeOrderView();
            result.orderDescription = descriptionPut.Text;
            result.orderID = ((EmployeeOrderView)EmployeeOrderGrid.SelectedItem).orderID;
            ((ApplicationView)DataContext).Update.Execute(result);
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            if (EmployeeOrderGrid.SelectedIndex == -1)
                return;
            ((ApplicationView)DataContext).Delete.Execute(((EmployeeOrderView)EmployeeOrderGrid.SelectedItem).orderID);
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            var result = new OrderTypeView();
            result.orderName = orderNamePost.Text;
            ((ApplicationView)DataContext).Add.Execute(result);
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            if (OrderTypeGrid.SelectedIndex == -1)
                return;
            var result = new OrderTypeView();
            result.orderName = orderNamePut.Text;
            result.orderTypeID = ((OrderTypeView)OrderTypeGrid.SelectedItem).orderTypeID;
            ((ApplicationView)DataContext).Update.Execute(result);
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            if (OrderTypeGrid.SelectedIndex == -1)
                return;
            ((ApplicationView)DataContext).Delete.Execute(((OrderTypeView)OrderTypeGrid.SelectedItem).orderTypeID);
        }
    }
}
