using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lab9.Data.ViewModel;
using Lab9.Data;
using System.Collections.ObjectModel;

namespace Lab9.Data.Mapping
{
    public static class Mapping
    {
        public static bool isInitialize { get; private set; }
        public static void Initialize()
        {
            if (isInitialize)
                return;
            Mapper.Initialize(ctg =>
            {
                ctg.CreateMap<Employee, EmployeeView>();
                ctg.CreateMap<EmployeeView, Employee>();
                ctg.CreateMap<Position, PositionView>();
                ctg.CreateMap<PositionView, Position>();
                ctg.CreateMap<Department, DepartmentView>();
                ctg.CreateMap<DepartmentView, Department>();
                ctg.CreateMap<OrderType, OrderTypeView>();
                ctg.CreateMap<OrderTypeView, OrderType>();
                ctg.CreateMap<EmployeeOrder, EmployeeOrderView>();
                ctg.CreateMap<EmployeeOrderView, EmployeeOrder>();
            });
            isInitialize = true;
        }
    }
}
