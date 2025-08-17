using API6sunday.Models;
using API6sunday.Repository;
using API6sunday.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using System.Runtime.CompilerServices;

namespace API6sunday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class departmentController : ControllerBase
    {
        private readonly Idepartment _dept;

        public departmentController(Idepartment dept)
        {
            _dept = dept;
        }

        [HttpGet]
        public async Task<IEnumerable<department>> GetAllDepts()
        {
            return await _dept.getalldepts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<department>> getdeptbyId(int id)
        {
            return await _dept.getdeptbyId(id); 
        }

        [HttpPost]
        public async Task<ActionResult<department>> AddDept(department department)
        {
            return await _dept.adddept(department);
        }

        [HttpPut]
        public async Task<ActionResult<department>> UpdateDept(int id, department department)
        {
            return await _dept.updatedept(id, department);
        }

        [HttpDelete]
        public async Task<ActionResult<department>> deletedept(int id)
        {
            return await _dept.deletedept(id);
        }
    }
}
