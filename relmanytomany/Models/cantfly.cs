using System.ComponentModel.DataAnnotations;

namespace relmanytomany.Models
{
    public class cantfly
    {
        [Key]
        public int cId { get; set; }
        [Required]
        public string bname { get; set; }
        public int age { get; set; }

        public virtual IEnumerable<both> both {  get; set; } = new List<both>();
    }
}
