using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.ViewModel
{
    public class DepartmentView :ViewBase
    {
        
        public int departmentID { get; set; }

        
        public string dname { get; set; }

        
        public virtual ICollection<EmployeeView> Employees { get; set; }
    }
}
