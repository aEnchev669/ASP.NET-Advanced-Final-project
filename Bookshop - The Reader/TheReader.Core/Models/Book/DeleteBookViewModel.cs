namespace TheReader.Core.Models.Book
{
    public class DeleteBookViewModel
    {
        public int Id { get; set; }
        public string Author { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
