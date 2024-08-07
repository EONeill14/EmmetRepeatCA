using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmmetRepeatCA.Models
{
    public class Vinyl
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int ArtistId { get; set; }

        public string Genre { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        // Navigation property
        public Artist Artist { get; set; } = new Artist();
    }
}
