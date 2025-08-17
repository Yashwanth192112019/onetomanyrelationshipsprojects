using System.ComponentModel.DataAnnotations;

namespace API6sunday.Models
{
    public class department
    {
        [Key]
        public int DId { get; set; }
        [Required]
        public string Dname { get; set; }

        public string Description { get; set; }

        public virtual ICollection<both> both { get; set; } = new List<both>();
    }
}
