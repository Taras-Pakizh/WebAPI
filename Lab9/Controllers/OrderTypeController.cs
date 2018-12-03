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
    public class OrderTypeController : ApiController
    {
        private OrderTypeService service;

        public OrderTypeController()
        {
            service = new OrderTypeService();
        }

        [HttpGet]
        public IEnumerable<OrderTypeView> Get()
        {
            return service.GetAll();
        }

        [HttpGet]
        public OrderTypeView Get(int id)
        {
            return service.GetById(id);
        }

        [HttpPost]
        public bool Post(OrderTypeView view)
        {
            return service.Add(view);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return service.Remove(id);
        }

        [HttpPut]
        public bool Update(OrderTypeView view)
        {
            return service.Update(view);
        }
    }
}
