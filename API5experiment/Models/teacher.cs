using System.ComponentModel.DataAnnotations;

namespace API5experiment.Models
{
    public class teacher
    {
        [Key]
        public int TId { get; set; }
        [Required]
        public string TName { get; set; }
        public string Description { get; set; }

        public ICollection<enrollment> enrollments { get; set; } = new List<enrollment>();

    }
}
