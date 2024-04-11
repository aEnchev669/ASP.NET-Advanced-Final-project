namespace TheReader.Core.Models.Book
{
    public class AllBooksFilteredAndPagedServiceModel
    {
        public int TotalBooksCount { get; set; }
        public IEnumerable<BookIndexViewModel> Books { get; set; } = new HashSet<BookIndexViewModel>();
    }
}
