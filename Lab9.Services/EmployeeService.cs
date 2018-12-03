using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab9.Data.ViewModel;
using Lab9.Data;

namespace Lab9.Services
{
    public class EmployeeService :IService<Employee, EmployeeView>
    {
        public EmployeeService()
        {
            entity = new EntityTask<Employee, EmployeeView>();
        }
    }
}
