using BussinessLogic.Service;
using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Overtime.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController() { }
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: api/Employee
        public IEnumerable<Employee> Get()
        {
            return _employeeService.Get();
        }

        // GET: api/Employee/5
        public Employee Get(int id)
        {
            var get = _employeeService.Get(id);
            return get;
        }

        // POST: api/Employee
        [HttpPost]
        public void Post(EmployeeParam employeeParam)
        {
            _employeeService.Insert(employeeParam);
        }

        // PUT: api/Employee/5
        public void Put(int id, EmployeeParam employeeParam)
        {
            _employeeService.Update(id, employeeParam);
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
            _employeeService.Delete(id);
        }
    }
}
