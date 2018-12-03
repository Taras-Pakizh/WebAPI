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
    public class EmployeeView : ViewBase
    {
        [DataMember]
        public int employeeID { get; set; }
        [DataMember]
        public string firstname { get; set; }
        [DataMember]
        public string lastname { get; set; }
        [DataMember]
        public DateTime? birthday { get; set; }
        [DataMember]
        public string gender { get; set; }
        
        public virtual DepartmentView Department1 { get; set; }
        
        public virtual ICollection<EmployeeOrderView> EmployeeOrders { get; set; }
        
        public virtual PositionView Position1 { get; set; }
        [DataMember]
        public int? position { get; set; }
        [DataMember]
        public int? department { get; set; }

        public override int GetId()
        {
            return employeeID;
        }
    }
}
