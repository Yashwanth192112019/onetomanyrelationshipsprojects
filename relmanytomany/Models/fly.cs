using System.ComponentModel.DataAnnotations;

namespace relmanytomany.Models
{
    public class fly
    {
        [Key]
        public int bId { get; set; }
        [Required]
        public string cname { get; set; }
        public int age { get; set; }
        public virtual IEnumerable<both> both { get; set; } = new List<both>();
    }
}
