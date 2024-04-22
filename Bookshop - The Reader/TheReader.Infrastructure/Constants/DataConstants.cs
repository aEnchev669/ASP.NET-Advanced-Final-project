namespace TheReader.Infrastructure.Constants
{
    public static class DataConstants
    {
        public const string DateTimeDefaultFormat = "dd/MM/yyyy";
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
            public const string PriceMinValue = "1.00";
            public const string PriceMaxValue = "10000.00";

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
            public const string WeightMinLength = "0.05";
            public const string WeightMaxLength = "5.00";

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

            //Username
            public const int UsernameMinLength = 2;
            public const int UserNameMaxLength = 60;
        }
		public static class EventConstants
		{
			public const string DateTimeFormat = "dd/MM/yyyy HH:mm";

			//Topic
			public const int EventTopicMinLength = 5;
			public const int EventTopicMaxLength = 120;

			//Description
			public const int EventDescriptionMinLength = 30;
			public const int EventDescriptionMaxLength = 4000;

			//Location
			public const int EventLocationMinLength = 5;
			public const int EventLocationMaxLength = 100;

			//Seats
			public const int EventSeatsMinRange = 1;
			public const uint EventSeatsMaxRange = uint.MaxValue;

			//Ticket Price
			public const int EventTicketPriceMinRange = 0;
			public const uint EventTicketPriceMaxRange = uint.MaxValue;
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

		public static class CartConstants
		{
			public const string TotalPriceMinValue = "0";
			public const string TotalPriceMaxValue = "2000000000";

			public const string QuantityMinValue = "0";
			public const string QuantityMaxValue = "100";
		}

		public static class CommentConstants
        {
            //Text
            public const int TextMinLength = 10;
            public const int TextMaxLength = 100;
        }
    }
}
