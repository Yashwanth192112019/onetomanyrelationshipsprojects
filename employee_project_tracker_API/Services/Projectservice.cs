using employee_project_tracker_API.Models;
using employee_project_tracker_API.Repository;
using Microsoft.EntityFrameworkCore;

namespace employee_project_tracker_API.Services
{
    public class Projectservice : IProject
    {
        private readonly context par;

        public Projectservice(context par)
        {
            this.par = par;
        }

        public async Task<IEnumerable<Project>> getallprojects()
        {
            return await par.projects.Include(e => e.Employees).ToListAsync();
        }

        public async Task<Project?> getprojectbyid(int id)
        {
            return await par.projects.Include(e => e.Employees).FirstOrDefaultAsync(e => e.ProjectId == id);
        }

    }
}
