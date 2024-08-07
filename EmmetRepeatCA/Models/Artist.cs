using System.ComponentModel.DataAnnotations;

namespace EmmetRepeatCA.Models
{
    public class Artist
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public string Bio {  get; set; }

        public ICollection<Vinyl> Vinyls { get; set; }
    }
}
