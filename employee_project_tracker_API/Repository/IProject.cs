using employee_project_tracker_API.Models;

namespace employee_project_tracker_API.Repository
{
    public interface IProject
    {
        Task<IEnumerable<Project>> getallprojects();
        Task<Project?> getprojectbyid(int id);
    }
}
