using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lab8.ViewModel;
using Lab8;
using System.Collections.ObjectModel;

namespace Lab8.Mapping
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

        public static IMapper CreateMapper_Employee_to_View()
        {
            return new MapperConfiguration(ctg =>
            {
                ctg.CreateMap<Employee, EmployeeView>();
            }).CreateMapper();
        }
        public static IMapper CreateMapper_View_to_Employee()
        {
            return new MapperConfiguration(ctg =>
            {
                ctg.CreateMap<EmployeeView, Employee>();
            }).CreateMapper();
        }

        public static IMapper CreateMapper_Position_to_View()
        {
            return new MapperConfiguration(ctg =>
            {
                ctg.CreateMap<Position, PositionView>();
            }).CreateMapper();
        }
        public static IMapper CreateMapper_View_to_Position()
        {
            return new MapperConfiguration(ctg =>
            {
                ctg.CreateMap<PositionView, Position>();
            }).CreateMapper();
        }

        public static IMapper CreateMapper_Department_to_View()
        {
            return new MapperConfiguration(ctg =>
            {
                ctg.CreateMap<Department, DepartmentView>();
            }).CreateMapper();
        }
        public static IMapper CreateMapper_View_to_Department()
        {
            return new MapperConfiguration(ctg =>
            {
                ctg.CreateMap<DepartmentView, Department>();
            }).CreateMapper();
        }

        public static IMapper CreateMapper_OrderType_to_View()
        {
            return new MapperConfiguration(ctg =>
            {
                ctg.CreateMap<OrderType, OrderTypeView>();
            }).CreateMapper();
        }
        public static IMapper CreateMapper_View_to_OrderType()
        {
            return new MapperConfiguration(ctg =>
            {
                ctg.CreateMap<OrderTypeView, OrderType>();
            }).CreateMapper();
        }

        public static IMapper CreateMapper_EmployeeOrder_to_View()
        {
            return new MapperConfiguration(ctg =>
            {
                ctg.CreateMap<EmployeeOrder, EmployeeOrderView>();
            }).CreateMapper();
        }
        public static IMapper CreateMapper_View_to_EmployeeOrder()
        {
            return new MapperConfiguration(ctg =>
            {
                ctg.CreateMap<EmployeeOrderView, EmployeeOrder>();
            }).CreateMapper();
        }
    }
}
