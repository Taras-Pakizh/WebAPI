﻿using System;
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
            var _department = MyGrig.SelectedItem as DepartmentView;
            if (_department == null)
                return;
            Employees = _department.Employees;
            ((ApplicationView)DataContext).Group.Execute(MyGrig.SelectedIndex);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (AddPanel.Visibility == Visibility.Hidden)
                AddPanel.Visibility = Visibility.Visible;
            else AddPanel.Visibility = Visibility.Hidden;
        }

        private void CommitAdd_Click(object sender, RoutedEventArgs e)
        {
            DepartmentView view = new DepartmentView();
            view.dname = dNameAdd.Text;
            var parameter = new ModifyParameter();
            view.departmentID = ((ApplicationView)DataContext).Departments.Max(x => x.departmentID) + 1;
            parameter.view = view;
            parameter.Add = true;
            int index = ((ApplicationView)DataContext).Technology;
            switch (index)
            {
                case 0:
                    ((ApplicationView)DataContext).UseEntity.Execute(parameter);
                    break;
                case 1:
                    ((ApplicationView)DataContext).UseAdo.Execute(parameter);
                    break;
                case 2:
                    ((ApplicationView)DataContext).UseLinq.Execute(parameter);
                    break;
            }
            //((ApplicationView)DataContext).UseEntity.Execute(parameter);
            AddPanel.Visibility = Visibility.Hidden;
        }

        private void CommitModify_Click(object sender, RoutedEventArgs e)
        {
            DepartmentView view = new DepartmentView();
            view.dname = dNameModify.Text;
            view.departmentID = Int32.Parse(departmentID.Text);
            var parameter = new ModifyParameter();
            parameter.view = view;
            parameter.Update = true;
            //((ApplicationView)DataContext).UseEntity.Execute(parameter);
            int index = ((ApplicationView)DataContext).Technology;
            switch (index)
            {
                case 0:
                    ((ApplicationView)DataContext).UseEntity.Execute(parameter);
                    break;
                case 1:
                    ((ApplicationView)DataContext).UseAdo.Execute(parameter);
                    break;
                case 2:
                    ((ApplicationView)DataContext).UseLinq.Execute(parameter);
                    break;
            }
            ModifyPanel.Visibility = Visibility.Hidden;
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            var _department = MyGrig.SelectedItem as DepartmentView;
            if (_department == null)
                return;
            dNameModify.Text = _department.dname;
            departmentID.Text = _department.departmentID.ToString();
            ModifyPanel.Visibility = Visibility.Visible;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MyGrig.SelectedIndex == -1)
                return;
            var _department = MyGrig.SelectedItem as DepartmentView;
            if (_department == null)
                return;
            //((ApplicationView)DataContext).UseEntity.Execute(_department);
            int index = ((ApplicationView)DataContext).Technology;
            switch (index)
            {
                case 0:
                    ((ApplicationView)DataContext).UseEntity.Execute(_department);
                    break;
                case 1:
                    ((ApplicationView)DataContext).UseAdo.Execute(_department);
                    break;
                case 2:
                    ((ApplicationView)DataContext).UseLinq.Execute(_department);
                    break;
            }
        }
    }
}