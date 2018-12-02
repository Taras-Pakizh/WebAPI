using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.ViewModel
{
    public class PositionView :ViewBase, IIdable
    {
        
        public int positionID { get; set; }

        
        public string positionName { get; set; }

        public double? salary { get; set; }

        
        public virtual ICollection<EmployeeView> Employees { get; set; }

        public int GetId()
        {
            return positionID;
        }
    }
}
