using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TheReader.Infrastructure.Constants
{
    public static class DataConstants
    {
        public static class BookConstants
        {
            //Title
            public const int TitleMinLength = 1;
            public const int TitleMaxLength = 70;

            //Author
            public const int AuthorMinLength = 2;
            public const int AuthorMaxLength = 50;

            //Discription
            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 2000;

            //Price
            public const double PriceMinValue = 1.00;
            public const double PriceMaxValue = 10000.00;

            //StockQuantity
            public const int StockQuantityMinValue = 1;
            public const int StockQuantityMaxValue = 150;

			//PublishedDate
			public const int PublishedYearMinRange = 1;
			public const int PublishedYearMaxRange = 2024;

            //ImageUrl
            public const int ImageUrlMinLegnth = 10;
            public const int ImageUrlMaxLegnth = 2048;

			//Language
			public const int LanguageMinLength = 5;
			public const int LanguageMaxLength = 30;

			//Weigth
			public const double WeightMinLength = 0.20;
			public const double WeightMaxLength = 5.00;

			//Pages
			public const int PagesMinLength = 5;
			public const int PagesMaxLength = 5000;
		}

        public static class GenreConstants
        {
            //Name
            public const int NameMinLength = 1;
            public const int NameMaxLength = 50;
		}

        public static class ApplicationUserConstants
        {
            //FirstName
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 60;

            //LastName
			public const int LastNameMinLength = 2;
			public const int LastNameMaxLength = 60;
        }

        public static class OrderConstants
        {
			//FiestName
			public const int FirstNameMinLength = 2;
			public const int FirstNameMaxLength = 50;

			//LastName
			public const int LastNameMinLength = 2;
			public const int LastNameMaxLength = 50;

			//Email
			public const int EmailMinLength = 10;
			public const int EmailMaxLength = 50;

			//Phone
			public const int PhoneMinLength = 10;
			public const int PhoneMaxLength = 15;
            
            //City
			public const int CityMinLength = 2;
			public const int CityMaxLength = 80;

			//PostalCode
			public const int PostalCodeMinLength = 4;
			public const int PostalCodeMaxLength = 4;

			//City
			public const int StreetMinLength = 3;
			public const int StreetMaxLength = 50;

			//TotalPrice
			public const double TotalPriceMinLength = 1.00;
			public const double TotalPriceMaxLength = 10000.00;
		}

		public static class CommentConstants
		{
			//Text
			public const int TextMinLength = 10;
			public const int TextMaxLength = 100;
		}
	}
}
