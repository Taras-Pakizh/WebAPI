using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.ViewModel
{
    public class DepartmentView :ViewBase, IIdable
    {
        
        public int departmentID { get; set; }

        
        public string dname { get; set; }

        
        public virtual ICollection<EmployeeView> Employees { get; set; }

        public int GetId()
        {
            return departmentID;
        }
    }
}
