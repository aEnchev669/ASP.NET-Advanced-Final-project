namespace TheReader.Core.Models.Book
{
    public class BookIndexViewModel
    {
        public int Id { get; set; }
        public long ISBN { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int PublishedYear { get; set; }

        public string Genre { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string Language { get; set; } = string.Empty;

        public double Weight { get; set; }

        public int Pages { get; set; }
    }
}
