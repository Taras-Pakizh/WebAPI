using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.ViewModel
{
    public class EmployeeView:ViewBase, IIdable
    {
        public int employeeID { get; set; }

        public string firstname { get; set; }
        
        public string lastname { get; set; }
        
        public DateTime? birthday { get; set; }
        
        public string gender { get; set; }

        public virtual DepartmentView Department1 { get; set; }

        public virtual ICollection<EmployeeOrderView> EmployeeOrders { get; set; }

        public virtual PositionView Position1 { get; set; }

        public int? position { get; set; }

        public int? department { get; set; }

        public int GetId()
        {
            return employeeID;
        }
    }
}
