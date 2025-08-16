using System.ComponentModel.DataAnnotations;

namespace API5experiment.Models
{
    public class student
    {
        [Key]
        public int SId { get; set; }

        [Required]
        public string SName { get; set; }
        public string Description { get; set; }

        public ICollection<enrollment> enrollments { get; set; } = new List<enrollment>();
    }
}
    