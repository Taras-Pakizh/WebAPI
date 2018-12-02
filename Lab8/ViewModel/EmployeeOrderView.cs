using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.ViewModel
{
    public class EmployeeOrderView :ViewBase
    {
        
        public int orderID { get; set; }

        
        public DateTime? orderDate { get; set; }

        public int? Employee { get; set; }

        public int? orderType { get; set; }

        
        public string orderDescription { get; set; }

        public virtual EmployeeView Employee1 { get; set; }

        public virtual OrderTypeView OrderType1 { get; set; }
    }
}
