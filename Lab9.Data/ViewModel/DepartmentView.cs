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
    public class DepartmentView : ViewBase
    {
        [DataMember]
        public int departmentID { get; set; }

        [DataMember]
        public string dname { get; set; }

        
        public virtual ICollection<EmployeeView> Employees { get; set; }

        public override int GetId()
        {
            return departmentID;
        }
    }
}
