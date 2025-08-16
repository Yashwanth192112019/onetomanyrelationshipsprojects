using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace newAPI2.Models
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }

        [Required]
        public string SpeciesName { get; set; }

        public string Description { get; set; }

        public string Habitat { get; set; }

     
        public virtual ICollection<Bird>? Birds { get; set; } = new List<Bird>();
    }
}