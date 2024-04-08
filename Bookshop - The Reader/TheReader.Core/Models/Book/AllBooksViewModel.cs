namespace TheReader.Core.Models.Book
{
    public class AllBooksViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }  = null!;
        public string Author{ get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageURL { get; set; } = null!;
    }
}
