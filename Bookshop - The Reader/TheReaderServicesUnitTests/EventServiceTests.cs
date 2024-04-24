using BookshopTheReader.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TheReader.Core.Contracts.Book;
using TheReader.Core.Contracts.Event;
using TheReader.Core.Models.Book;
using TheReader.Core.Models.Event;
using TheReader.Core.Services;
using TheReader.Infrastructure.Data.Models.Books;

namespace TheReaderServicesUnitTests
{
	public class EventServiceTests
	{
		private DbContextOptions<TheReaderDbContext> dbOptions;
		private TheReaderDbContext dbContext;

		private IEventService eventService;

		private int eventId;

		[SetUp]
		public void SetUp()
		{
			dbOptions = new DbContextOptionsBuilder<TheReaderDbContext>()
				.UseInMemoryDatabase("TheReaderInMemoryDb" )
				.Options;

			dbContext = new TheReaderDbContext(dbOptions);

			dbContext.Database.EnsureCreated();
			SeedData.SeedDatabase(dbContext);

			eventService = new EventService(dbContext);

			eventId = 1;
		}

		[TearDown]
		public void TearDown()
		{
			dbContext.Database.EnsureDeleted();
		}

		[Test]
		public async Task AddEventAsync_ShouldReturnListOfAllEvents()
		{
			var expected = await dbContext
			.Events
			.ToListAsync();

			var result = await eventService.AllAsync();

			Assert.That(expected, Has.Count.EqualTo(result.Count()));
		}

		[Test]
		public async Task DeleteEventAsync_ShouldReturnCorrectCount()
		{
			var currEvent = await dbContext
				.Events
				.FirstOrDefaultAsync(b => b.Id == eventId);

			var expected = new DeleteEventViewModel()
			{
				Id = currEvent.Id,
				Topic = currEvent.Topic,
				Location = currEvent.Location,
			};

			var result = eventService.DeleteEventAsync(eventId);

			Assert.AreEqual(expected.Topic, (result.Topic));
		}

		[Test]
		public async Task CreateBookAsync_ShouldAddItemToCollection()
		{
			var currEvent = await dbContext
				.Events
				.FirstOrDefaultAsync(b => b.Id == eventId);

			var before = await dbContext
				.Events
				.ToListAsync();

			var model = new EventFormViewModel()
			{
				Topic = currEvent.Topic + "Test",
				Description = currEvent.Description + "Test",
				Location = currEvent.Location + "Test",
				Date = currEvent.Date ,
				Seats = currEvent.Seats + 1,
				TicketPrice = currEvent.TicketPrice + 2
			};

			await eventService.AddEventAsync(model);

			var result = await dbContext
				.Events
				.ToListAsync();

			Assert.That(result, Has.Count.EqualTo(before.Count() + 1));
		}

		[Test]
		public async Task DeleteBookConfirmAsync_ShouldTurnIsDeleteToTrue()
		{
			var currEvent = await dbContext
				.Events
				.Where(i => i.Id == eventId)
				.FirstAsync();

			Assert.That(currEvent.IsDeleted, Is.False);

			await eventService.DeleteEventConfirmedAsync(eventId);

			Assert.That(currEvent.IsDeleted, Is.True);
		}

		[Test]
		public async Task DetailsAsync_ShouldReturnRightItem()
		{
			var expected = await dbContext
				.Events
				.Where(i => i.Id == eventId)
				.FirstAsync();

			var result = await eventService.DetailsAsync(eventId);

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(expected.Topic, Is.EqualTo(result.Topic));
				Assert.That(expected.Description, Is.EqualTo(result.Description));
				Assert.That(expected.Description, Is.EqualTo(result.Description));
				Assert.That(expected.Location, Is.EqualTo(result.Location));
				Assert.That(expected.Date, Is.EqualTo(result.Date));
				Assert.That(expected.Seats, Is.EqualTo(result.Seats));
				Assert.That(expected.TicketPrice, Is.EqualTo(result.TicketPrice));
			});
		}

		[Test]
		public async Task EditEventAsync_ShouldReturnModifiedItem()
		{
			var currEvent = await dbContext
				.Events
				.FirstOrDefaultAsync(b => b.Id == eventId);

			var model = new EventFormViewModel()
			{
				Topic = currEvent.Topic + "Test",
				Description = currEvent.Description + "Test",
				Location = currEvent.Location + "Test",
				Date = currEvent.Date,
				Seats = currEvent.Seats + 1,
				TicketPrice = currEvent.TicketPrice + 2
			};

			await eventService.EditEventAsync(eventId, model);

			var result = await dbContext
				.Events
				.Where(i => i.Id == eventId)
				.FirstAsync();

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(model.Topic, Is.EqualTo(result.Topic));
				Assert.That(model.Description, Is.EqualTo(result.Description));
				Assert.That(model.Description, Is.EqualTo(result.Description));
				Assert.That(model.Location, Is.EqualTo(result.Location));
				Assert.That(model.Date, Is.EqualTo(result.Date));
				Assert.That(model.Seats, Is.EqualTo(result.Seats));
				Assert.That(model.TicketPrice, Is.EqualTo(result.TicketPrice));
			});
		}

		[Test]
		public async Task BookExistsAsync_ShouldReturnFalse()
		{
			int existEvent = 2332246;

			bool result = await eventService.EventExistsAsync(existEvent);

			Assert.That(result, Is.False);
		}

		[Test]
		public async Task BookExistsAsync_ShouldReturnTrue()
		{
			int existEvent = 1;

			bool result = await eventService.EventExistsAsync(existEvent);

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task GetBookByIdAsync_ShouldReturnCorrectItem()
		{
			var model = await dbContext
				.Events
				.Where(i => i.Id == eventId)
			.FirstAsync();

			var result = await eventService.FindEventByIdAsync(eventId);

			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);

				Assert.That(model.Topic, Is.EqualTo(result.Topic));
				Assert.That(model.Description, Is.EqualTo(result.Description));
				Assert.That(model.Description, Is.EqualTo(result.Description));
				Assert.That(model.Location, Is.EqualTo(result.Location));
				Assert.That(model.Date, Is.EqualTo(result.Date));
				Assert.That(model.Seats, Is.EqualTo(result.Seats));
				Assert.That(model.TicketPrice, Is.EqualTo(result.TicketPrice));
			});

		}
	}
}
