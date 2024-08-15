using EmmetRepeatCA.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace EmmetRepeatCA.Services
{
    public class DataPrinterService
    {
        private readonly StoreDbContext _context;

        public DataPrinterService(StoreDbContext context)
        {
            _context = context;
        }

        public void PrintData()
        {
            var artists = _context.Artists.ToList();
            var vinyls = _context.Vinyls.ToList();

            Console.WriteLine("Artists:");
            foreach (var artist in artists)
            {
                Console.WriteLine($"ID: {artist.ArtistId}, Name: {artist.Name}, Bio: {artist.Bio}");
            }

            Console.WriteLine("\nVinyls:");
            foreach (var vinyl in vinyls)
            {
                Console.WriteLine($"ID: {vinyl.VinylId}, Title: {vinyl.Title}, Genre: {vinyl.Genre}, " +
                                  $"Price: {vinyl.Price}, ReleaseDate: {vinyl.ReleaseDate.ToShortDateString()}, " +
                                  $"Artist: {vinyl.Artist?.Name}");
            }
        }
    }
}
