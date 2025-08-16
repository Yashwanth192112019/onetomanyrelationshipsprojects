using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace newAPI2.Models
{
    public class Bird
    {
        [Key]
        public int BirdId { get; set; }

        [Required]
        public string BirdName { get; set; } 

        public int Age { get; set; }

        public string Color { get; set; }

        public int AnimalId { get; set; }

        [ForeignKey("AnimalId")]
        public virtual Animal? Animal { get; set; }


    }
}