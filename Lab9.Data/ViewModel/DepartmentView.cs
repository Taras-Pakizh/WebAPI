using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.Data.ViewModel
{
    public class DepartmentView : ViewBase
    {

        public int departmentID { get; set; }


        public string dname { get; set; }


        public virtual ICollection<EmployeeView> Employees { get; set; }

        public override int GetId()
        {
            return departmentID;
        }
    }
}
