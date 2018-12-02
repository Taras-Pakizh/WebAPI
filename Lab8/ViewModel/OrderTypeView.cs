using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.ViewModel
{
    public class OrderTypeView :ViewBase
    {
        
        public int orderTypeID { get; set; }

        
        public string orderName { get; set; }

        
        public virtual ICollection<EmployeeOrderView> EmployeeOrders { get; set; }
    }
}
