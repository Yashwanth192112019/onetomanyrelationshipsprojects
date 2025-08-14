using employee_project_tracker_API.Models;
using employee_project_tracker_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employee_project_tracker_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee emp;

        public EmployeeController(IEmployee emp)
        {
            this.emp = emp;
        }


        [HttpGet]
        public async Task<IEnumerable<Employee>> GetallEmployees()
        {
            return await emp.getallemployee();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> getemployeebyid(int id)
        {
            return await emp.getemployeebyid(id);
        } 
    }
}
