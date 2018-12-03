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
    public class PositionView : ViewBase
    {
        [DataMember]
        public int positionID { get; set; }

        [DataMember]
        public string positionName { get; set; }

        [DataMember]
        public double? salary { get; set; }

        
        public virtual ICollection<EmployeeView> Employees { get; set; }

        public override int GetId()
        {
            return positionID;
        }
    }
}
