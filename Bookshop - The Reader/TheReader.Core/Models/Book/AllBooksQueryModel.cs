using System.ComponentModel.DataAnnotations;
using TheReader.Core.Models.Book.Enums;
using static TheReader.Infrastructure.Constants.ApplicaitonConstants;
namespace TheReader.Core.Models.Book
{
    public class AllBooksQueryModel
    {
        public AllBooksQueryModel()
        {
            CurrentPage = DefaultPage;
            ItemsPerPage = ItemsPerPageConstant;
        } 

        public string? Category { get; set; }

        [Display(Name = "Search by type")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort By:")]
        public BooksSorting ItemSorting { get; set; }

        public int CurrentPage { get; set; }

        public int ItemsPerPage { get; set; }

        public int TotalItems { get; set; }

        public IEnumerable<string> Categories { get; set; } = new HashSet<string>();

        public IEnumerable<AllBooksViewModel> Books { get; set; } = new HashSet<AllBooksViewModel>();
    }
}
