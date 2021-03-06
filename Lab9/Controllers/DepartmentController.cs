﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab9.Services;
using Lab9.Data.ViewModel;

namespace Lab9.Controllers
{
    public class DepartmentController : ApiController
    {
        private DepartmentService service;

        public DepartmentController()
        {
            service = new DepartmentService();
        }

        [HttpGet]
        public IEnumerable<DepartmentView> Get()
        {
            return service.GetAll();
        }

        [HttpGet]
        public DepartmentView Get(int id)
        {
            return service.GetById(id);
        }

        [HttpPost]
        public bool Post(DepartmentView view)
        {
            return service.Add(view);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return service.Remove(id);
        }

        [HttpPut]
        public bool Update(DepartmentView view)
        {
            return service.Update(view);
        }
    }
}
