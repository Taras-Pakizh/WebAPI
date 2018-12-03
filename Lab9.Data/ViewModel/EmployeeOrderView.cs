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
    public class EmployeeOrderView : ViewBase
    {
        [DataMember]
        public int orderID { get; set; }

        [DataMember]
        public DateTime? orderDate { get; set; }
        [DataMember]
        public int? Employee { get; set; }
        [DataMember]
        public int? orderType { get; set; }

        [DataMember]
        public string orderDescription { get; set; }
        
        public virtual EmployeeView Employee1 { get; set; }
        
        public virtual OrderTypeView OrderType1 { get; set; }

        public override int GetId()
        {
            return orderID;
        }
    }
}
