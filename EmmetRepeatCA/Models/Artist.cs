using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmmetRepeatCA.Models
{
    public class Artist
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Bio { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Vinyl> Vinyls { get; set; } = new List<Vinyl>();
    }
}
