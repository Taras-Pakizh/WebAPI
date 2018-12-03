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
    public class PositionController : ApiController
    {
        private PositionService service;

        public PositionController()
        {
            service = new PositionService();
        }

        [HttpGet]
        public IEnumerable<PositionView> Get()
        {
            return service.GetAll();
        }

        [HttpGet]
        public PositionView Get(int id)
        {
            return service.GetById(id);
        }

        [HttpPost]
        public bool Post(PositionView view)
        {
            return service.Add(view);
        }

        [HttpDelete]
        public bool Delete(PositionView view)
        {
            return service.Remove(view);
        }

        [HttpPut]
        public bool Update(PositionView view)
        {
            return service.Update(view);
        }
    }
}
