using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Lab9.Data.ViewModel
{
    [DataContract]
    public class OrderTypeView : ViewBase
    {
        [DataMember]
        public int orderTypeID { get; set; }

        [DataMember]
        public string orderName { get; set; }

        
        public virtual ICollection<EmployeeOrderView> EmployeeOrders { get; set; }

        public override int GetId()
        {
            return orderTypeID;
        }
    }
}
