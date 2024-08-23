using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmmetRepeatCA.Models
{
    public class Vinyl
    {
        public int VinylId { get; set; }

        [Required(ErrorMessage = "Please Enter the name of the record?")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please Enter the Genre of the record?")]
        public string Genre { get; set; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage ="Please enter a positive price")]
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int ArtistId { get; set; }
        public Artist Artist { get; set; } = new Artist();

    }
}
