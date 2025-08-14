using System.ComponentModel.DataAnnotations;

namespace employee_project_tracker_API.Models
{
    public class Project
    {
        [Key]
        public int ProjectId{ get; set; }
        [Required]
        [MaxLength(10)]
        public string ProjectCode{ get; set; }
        [Required]
        [MaxLength(100)]
        public string ProjectName{ get; set; }
        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate {  get; set; }

        [Required]
        public double Budget { get; set; }

        public virtual ICollection<Employee?> Employees { get; set; } = new List<Employee>();
    }
}
