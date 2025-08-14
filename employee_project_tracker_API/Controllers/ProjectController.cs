using employee_project_tracker_API.Models;
using employee_project_tracker_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employee_project_tracker_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProject par;

        public ProjectController(IProject par)
        {
            this.par = par;
        }

        [HttpGet]
        public async Task<IEnumerable<Project>> GetallProjects()
        {
            return await par.getallprojects();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> getprojectbyid(int id)
        {
            return await par.getprojectbyid(id);
        }

    }
}
