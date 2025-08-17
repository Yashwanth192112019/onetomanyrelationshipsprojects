using System.ComponentModel.DataAnnotations;

namespace API6sunday.Models
{
    public class employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<both> both { get; set; } = new List<both>();
    }
}
