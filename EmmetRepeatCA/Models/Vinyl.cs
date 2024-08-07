using Microsoft.AspNetCore.Components.Routing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmmetRepeatCA.Models
{
    public class Vinyl
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int ArtistId { get; set; }
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Column(TypeName ="decimal(18, 2)")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public Artist Artist { get; set; }

    }
}
