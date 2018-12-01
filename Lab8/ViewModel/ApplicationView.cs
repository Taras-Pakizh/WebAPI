using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Lab8.ViewModel
{
    class ApplicationView : INotifyPropertyChanged
    {
        private MyModel _model;
        public ApplicationView()
        {
            _model = new MyModel();
            _employees = new ObservableCollection<Employee>(_model.Employees);
        }

        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Table
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Table));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
