using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab9.Data.ViewModel;
using Lab9.Data;

namespace Lab9.Services
{
    public class PositionService :IService<Position, PositionView>
    {
        public PositionService()
        {
            entity = new EntityTask<Position, PositionView>();
        }
    }
}
