using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheReader.Core.Models.Book
{
	public class BookServiceIndexModel
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;

		public string Author { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = string.Empty;
	}
}
