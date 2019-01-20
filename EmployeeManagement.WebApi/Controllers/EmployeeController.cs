using EmployeeManagement;
using EmployeeManagement.Entities;
using EmployeeManagement.Repository;
using EmployeeManagement.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagement.WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private IEmployeeRepository _employee;
        private EmployeeController()
        {
            this._employee = new EmployeeRepository(new EmployeeContex());
        }
        [HttpGet]
        [Route("api/employees")]
        public IEnumerable<Employee> Get()
        {
            var data = _employee.GetEmpolyee();
            return data;
        }
    }
}
