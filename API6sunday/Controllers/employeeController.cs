using API6sunday.Models;
using API6sunday.Repository;
using API6sunday.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API6sunday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class employeeController : ControllerBase
    {
        private readonly Iemployee _emp;

        public employeeController(Iemployee emp)
        {
            _emp = emp;
        }

        [HttpGet]
        public async Task<IEnumerable<employee>> GetEmployees()
        {
            return await _emp.getallemployee();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<employee>> GetEmpById(int id)
        {
            return await _emp.getemployeebyId(id);
        }

        [HttpPost]
        public async Task<ActionResult<employee>> AddEmployee(employee employee)
        {
            return await _emp.addemployee(employee);
        }
        [HttpPut]
        public async Task<ActionResult<employee>> UpdateEmployee(int id, employee employee)
        {
            return await _emp.updateemployee(id, employee);
        }

        [HttpDelete]
        public async Task<ActionResult<employee>> DeleteEmployee(int id)
        {
            return await _emp.deleteemployee(id);
        }
    }
}
