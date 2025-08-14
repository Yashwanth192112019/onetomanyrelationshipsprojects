using System.Runtime.CompilerServices;
using employee_project_tracker_API.Models;
using employee_project_tracker_API.Repository;
using Microsoft.EntityFrameworkCore;

namespace employee_project_tracker_API.Services
{
    public class Employeeservice : IEmployee
    {
        private readonly context emp;

        public Employeeservice(context context)
        {
            emp = context;
        }

        public async Task<IEnumerable<Employee>> getallemployee()
        {
            return await emp.Employees.Include(e => e.Project).ToListAsync();
        }

        public async Task<Employee?> getemployeebyid(int id)
        {
            return await emp.Employees.Include(e => e.Project).FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

    }
}
