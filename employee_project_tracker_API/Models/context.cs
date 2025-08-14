using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace employee_project_tracker_API.Models
{
    public class context : DbContext
    {
        public context() { }

        public context(DbContextOptions<context> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("data source = YASH_MALLADI; database = parject; integrated security = true; trustservercertificate = true;");

        //seeding


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasData(new Employee() { EmployeeId = 1, FullName = "greenday", Designation = "dishwasher", Email = "greenday@gmail.com", EmployeeCode = "192112013", ProjectId = 2, Salary = 22159 },
                new Employee() { EmployeeId = 2, FullName = "yashwanthsai", Designation = "washdisher", Email = "kgf007@gmail.com", EmployeeCode = "192112014", ProjectId = 1, Salary = 45000 });
            modelBuilder.Entity<Project>()
                .HasData(new Project() { ProjectId = 1, Budget = 50000, ProjectCode = "ECA0501", ProjectName = "Haspital", StartDate = new DateTime(2024, 05, 28), EndDate = null },
                new Project()
                {
                    ProjectId = 2,
                    Budget = 80000,
                    ProjectCode = "ECA0502",
                    ProjectName = "Hastel",
                    StartDate = new DateTime(2025, 01, 4),
                    EndDate = new DateTime(2025, 05, 30)
                });
        }


    }
}
