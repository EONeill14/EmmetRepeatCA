namespace EmmetRepeatCA.Models
{
    public class Vinyl
    {
        public int VinylId { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int ArtistId { get; set; }
        public Artist Artist { get; set; } = new Artist();

    }
}
