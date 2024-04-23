using BookshopTheReader.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TheReader.Core.Contracts.Book;
using TheReader.Core.Contracts.Genre;
using TheReader.Core.Models.Book;
using TheReader.Core.Services;
using TheReader.Infrastructure.Data.Models.Books;
using static System.Reflection.Metadata.BlobBuilder;

namespace TheReader.Services.BookServiceTests
{
	
	public class BookAndGenreServiceTests
	{
		private IBookService bookService;
		private IGenreService genreService;

		private TheReaderDbContext dbContext;
		private IEnumerable<Book> books;
		private IEnumerable<Genre> genres;

		private DbContextOptionsBuilder<TheReaderDbContext> dbOptions;


		//Books
		public Book Trillions { get; set; } = null!;
		public Book TheStoryOfTheKamasutra { get; set; } = null!;
		public Book ElonMusk { get; set; } = null!;
		public Book RichDadPoorDad { get; set; } = null!;

		//Genres
		public Genre Fantasy { get; set; } = null!;
		public Genre ScienceFiction { get; set; } = null!;
		public Genre Classic { get; set; } = null!;
		public Genre Mystery { get; set; } = null!;
		public Genre Horror { get; set; } = null!;
		public Genre Finance { get; set; } = null!;
		public Genre Biography { get; set; } = null!;
		public Genre FoodAndDrink { get; set; } = null!;
		public Genre History { get; set; } = null!;
		public Genre Travel { get; set; } = null!;
		public Genre Crime { get; set; } = null!;

		[SetUp]
		public void Setup()
		{
			//Genres
			Fantasy = new Genre()
			{
				Id = 1,
				Name = "Фантазия"
			};
			ScienceFiction = new Genre()
			{
				Id = 2,
				Name = "Научна фантастика"
			};
			Classic = new Genre()
			{
				Id = 3,
				Name = "Класика"
			};
			Mystery = new Genre()
			{
				Id = 4,
				Name = "Мистерия"
			};
			Horror = new Genre()
			{
				Id = 5,
				Name = "Ужаси"
			};
			Finance = new Genre()
			{
				Id = 6,
				Name = "Финанси"
			};
			Biography = new Genre()
			{
				Id = 7,
				Name = "Биография"
			};
			FoodAndDrink = new Genre()
			{
				Id = 8,
				Name = "Храни и напитки"
			};
			History = new Genre()
			{
				Id = 9,
				Name = "История"
			};
			Travel = new Genre()
			{
				Id = 10,
				Name = "Пътуване"
			};
			Crime = new Genre()
			{
				Id = 11,
				Name = "Престъпление"
			};

			//Books

			Trillions = new Book()
			{
				Id = 1,
				ISBN = 9781473675988,
				Title = "Трилиони",
				Author = "Колектив",
				Description = "Бил Кембъл изигра инструментална роля в растежа на няколко видни компании като Google, Apple и Intuit, насърчавайки дълбоки връзки с визионери от Силициевата долина, включително Стив Джобс, Лари Пейдж и Ерик Шмид. В допълнение, този бизнес гений е ментор на десетки други важни лидери на двата бряга, от предприемачи до рискови капиталисти до педагози до футболисти, оставяйки след смъртта си през 2016 г. наследство от разрастващи се компании, успешни хора, уважение, приятелство и любов.Лидерите в Google в продължение на повече от десетилетие, Ерик Шмид, Джонатан Розенберг и Алън Ийгъл изпитаха от първа ръка как човекът, известен като треньора Бил, изгради доверителни взаимоотношения, насърчи личностното израстване – дори при тези на върха на кариерата си – вдъхнови смелост и идентифицира и разреши тлеещото напрежение, което неизбежно възниква в бързо променящи се среди. За да почетат своя наставник и да вдъхновят и учат бъдещите поколения, те са кодирали неговата мъдрост в това основно ръководство.Въз основа на интервюта с над осемдесет души, които са познавали и обичали Бил Кембъл, Trillion Dollar Coach обяснява принципите на треньора и ги илюстрира с истории от много велики хора и компании, с които е работил. Резултатът е план за далновидни бизнес лидери и мениджъри, който ще им помогне да създадат по-ефективни и по-бързо развиващи се култури, екипи и компании.",
				Price = 26,
				PublishedYear = 2020,
				GenreId = 6,
				ImageUrl = "https://cdn.ozone.bg/media/catalog/product/cache/1/image/a4e40ebdc3e371adff845072e1c73f37/t/r/2b7a8621ac2bd4eaa7e74423ad815c14/trillion-dollar-coach-30.jpg",
				Language = "Български",
				Weight = 0.17,
				Pages = 240
			};
			TheStoryOfTheKamasutra = new Book()
			{
				Id = 2,
				ISBN = 9545283033,
				Title = "Камасутра",
				Author = "Ватсаяна Маланага",
				Description = "За първи път на български в оригиналния си и най-пълен вариант излиза един от най-дискутираните и експлоатирани текстове на древността – древноиндийската библия на любовното изкуство “Камасутра” от Ватсаяна Маланага.Сутра е древен свещен текст, сборник от учения, препоръки и наставления, а Кама – наслаждаване с ръководените от разума сетива, съединени с тялото и съзнанието за удоволствието, породено от докосването на тялото. “След като създаде мъжа и жената, Праджапати (“владетелят на сътвореното”, бащата на боговете, творецът на света) създаде и учение от сто хиляди части, което да ги води в живота им.” В първоначалния си вид това учение се е състояло от три главни части – за дхарма (духовния живот), артхи (социалния живот) и кама (сетивния живот). По-късно сакралният текст за кама бил многократно преправян и съкращаван, докато се оформи достигналият до нас от ІІ в. сл. хр. окончателен вариант на Ватсаяна Маланага. В този вариант учението е оформено в 7 раздела – за общите въпроси, за прегръдките, за любовното сливане, за единствената съпруга, за чуждите жени, за куртизанките, за изкуството на прелъстяването, церовете за сила и пр.Всъщност, учението на Камасутра не предлага единствено система от техники, любовни пози или методи за извличане на максимална наслада, а също многобройни съвети за уменията, които любовниците трябва да проявят в акта на сливане:",
				Price = 15.60M,
				PublishedYear = 2008,
				GenreId = 3,
				ImageUrl = "https://cdn.ozone.bg/media/catalog/product/cache/1/image/a4e40ebdc3e371adff845072e1c73f37/k/a/26310e438a5a1fb8622738f1e5d34f8b/kamasutra-31.jpg",
				Language = "Български",
				Weight = 0.280,
				Pages = 200
			};
			ElonMusk = new Book()
			{
				Id = 4,
				ISBN = 9789547713611,
				Title = "Илън Мъск",
				Author = "Ашли Ванс",
				Description = "Единствената официална биография на Илън Мъск, написана с неговото специално съдействие.Илън Мъск - човекът зад PayPal, Tesla Motors, SpaceX, SolarCity, Hyperloop и идеята за глобална комуникационна мрежа. Гениалният визионер - Хенри Форд, Томас Едисън и Стив Джобс в едно. Най-дръзкият предприемач на Силициевата долина: инженер, изобретател и индустриалец. Прагматикът и фантастът, който подготвя човечеството за колонизация на Марс.Мъск стои начело на един от най-големите подеми в историята на бизнеса. Той е единственият предприемач с достатъчно енергия, сила и въображение, който инвестира цялото си богатство в иновации от друго измерение и революционизира три индустрии едновременно - космическата, автомобилната и енергийната. Мисията на живота му изглежда фантастична, но ако Мъск успее да си купи достатъчно време, той ще предприеме най-голямото пътуване за спасение на човечеството.Написана след повече от 50 часа разговори с Мъск и интервюта с около 300 души, книгата проследява пътя от нелекото детство на Илън Мъск в ЮАР до върховете на световния бизнес. Авторът Ашли Ванс разказва историите на компаниите на Мъск, които променят света, и живота на човека, който, независимо дали е обичан, или мразен, възхваляван или отричан, създава едно невероятно бъдеще.Бестселър на Ню Йорк Таймс и една от най-добрите книги на 2015 г. според Уолстрийт Джърнал и Амазон.Иска ми се да умра с мисълта, че пред човечеството има светло бъдеще. Ако можем да си осигурим чиста енергия и да станем междупланетарна раса с устойчива цивилизация на друга планета - за да се справим с най-лошия сценарий, в който човешкото съзнание е заличено - тогава... мисля, че ще бъде много хубаво.Илън Мъск Ашли Ванс е журналист, завършил колежа Pomona. Повече от 10 години пише за технологичната индустрия в Сан Франциско и е известен историк на Силициевата долина. Работил е за New York Times и The Register, а понастоящем - за списание Bloomberg Businessweek. Водещ е на телевизионно предаване.",
				Price = 25,
				PublishedYear = 2016,
				GenreId = 7,
				ImageUrl = "https://www.book.store.bg/lrgimg/180958/ilyn-mysk-biografia.jpg",
				Language = "Български",
				Weight = 0.596,
				Pages = 416
			};
			RichDadPoorDad = new Book()
			{
				Id = 5,
				ISBN = 9789542929550,
				Title = "Богат татко, беден татко",
				Author = "Робърт Кийосаки",
				Description = "Уроците за парите, на които богатите учат децата си, а бедните и средната класа - не. Робърт Кийосаки промени начина, по който милиони хора по света мислят за парите. Той притежава репутация на човек, чиито възгледи често противоречат на конвенционалното мислене със своята смелост и безкомпромисна откровеност. Той е световно признат експерт по финансова грамотност.",
				Price = 15.95M,
				PublishedYear = 2018,
				GenreId = 6,
				ImageUrl = "https://cdn.ozone.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/b/o/08f6ab8aa9194c941520c56f863d199c/bogat-tatko--beden-tatko-30.jpg",
				Language = "Български",
				Weight = 0.39,
				Pages = 360
			};


			//Databases
			var options = new DbContextOptionsBuilder<TheReaderDbContext>()
				.UseInMemoryDatabase(databaseName: "TheReaderInMemoryDb" + Guid.NewGuid().ToString())
			.Options;

			dbContext = new TheReaderDbContext(options);

			dbContext.AddRangeAsync(books);
			dbContext.AddRangeAsync(genres);
			dbContext.SaveChanges();

			bookService = new BookService(dbContext);
			genreService = new GenreService(dbContext);
		}

		[TearDown]
		public async Task Teardown()
		{
			await this.dbContext.Database.EnsureDeletedAsync();
			await this.dbContext.DisposeAsync();
		}

		[Test]
		public async Task Test_AllGenresNamesAsync_ReturnsTheCorrectResult()
		{
			// Act
			var allGenres = await genreService.AllGenresAsync();
			var result = allGenres.Select(ae => ae.Name);
			var expectedResult = new List<string>() { "Фантазия", "Научна фантастика", "Класика", "Мистерия", "Ужаси", "Финанси", "Биография", "Храни и напитки", "История", "Пътуване", "Престъпление" };

			// Assert
			Assert.That(result.Count(), Is.EqualTo(11));
			Assert.That(result, Is.EqualTo(expectedResult));
		}

		[Test]
		public async Task CreateBookAsync_ShouldAddItemToCollection()
		{
			var before = await dbContext
				.Books
				.ToListAsync();

			var model = new BookFormViewModel()
			{
				Title = "Test Title",
				Description = "Test Description",
				ImageUrl = "TestImage.png",
				Price = 2.33M,
				GenreId = 2
			};

			await bookService.CreateBookAsync(model);

			var result = await dbContext
				.Books
				.ToListAsync();

			Assert.That(result, Has.Count.EqualTo(before.Count() + 1));
		}

	}
}