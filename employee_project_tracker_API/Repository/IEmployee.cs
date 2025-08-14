using employee_project_tracker_API.Models;

namespace employee_project_tracker_API.Repository
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> getallemployee();
        Task<Employee?> getemployeebyid(int id);

    }
}
