using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab9.Services;
using Lab9.Data.ViewModel;

namespace Lab9.Controllers
{
    public class EmployeeOrderController : ApiController
    {
        private EmployeeOrderService service;

        public EmployeeOrderController()
        {
            service = new EmployeeOrderService();
        }

        [HttpGet]
        public IEnumerable<EmployeeOrderView> Get()
        {
            return service.GetAll();
        }

        [HttpGet]
        public EmployeeOrderView Get(int id)
        {
            return service.GetById(id);
        }

        [HttpPost]
        public bool Post(EmployeeOrderView view)
        {
            return service.Add(view);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return service.Remove(id);
        }

        [HttpPut]
        public bool Update(EmployeeOrderView view)
        {
            return service.Update(view);
        }
    }
}
