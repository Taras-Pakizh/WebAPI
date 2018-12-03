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
    public class EmployeeController : ApiController
    {
        private EmployeeService service;

        public EmployeeController()
        {
            service = new EmployeeService();
        }

        [HttpGet]
        public IEnumerable<EmployeeView> Get()
        {
            return service.GetAll();
        }

        [HttpGet]
        public EmployeeView Get(int id)
        {
            return service.GetById(id);
        }

        [HttpPost]
        public bool Post(EmployeeView view)
        {
            return service.Add(view);
        }

        [HttpDelete]
        public bool Delete(EmployeeView view)
        {
            return service.Remove(view);
        }

        [HttpPut]
        public bool Update(EmployeeView view)
        {
            return service.Update(view);
        }
    }
}
