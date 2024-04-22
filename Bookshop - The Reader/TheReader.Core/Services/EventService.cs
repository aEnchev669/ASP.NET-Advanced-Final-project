using BookshopTheReader.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TheReader.Core.Contracts.Event;
using TheReader.Core.Models.Event;
using TheReader.Infrastructure.Data.Models.Events;

namespace TheReader.Core.Services
{
	public class EventService : IEventService
	{
		private readonly TheReaderDbContext dbContext;

		public EventService(TheReaderDbContext _dbContext)
		{
			dbContext = _dbContext;
		}


		public async Task<int> AddEventAsync(EventFormViewModel eventForm)
		{
			Event currentEvent = new Event()
			{
				Topic = eventForm.Topic,
				Description = eventForm.Description,
				Location = eventForm.Location,
				Date = eventForm.Date,
				Seats = eventForm.Seats,
				TicketPrice = eventForm.TicketPrice
			};

			await dbContext.AddAsync(currentEvent);
			await dbContext.SaveChangesAsync();

			return currentEvent.Id;
		}

		public async Task<ICollection<AllEventViewModel>> AllAsync()
		{
			var events = await dbContext
				.Events
				.AsNoTracking()
				.Where(e => e.IsDeleted == false)
				.OrderBy(e => e.Date)
				.Select(e => new AllEventViewModel
				{
					Id = e.Id,
					Topic = e.Topic,
					Date = e.Date,
					Location = e.Location,
				})
				.ToArrayAsync();

			return events;
		}

		public DeleteEventViewModel DeleteEventAsync(int eventId)
		{
			var currEvent = dbContext
				.Events
				.AsNoTracking()
				.Where(b => b.Id == eventId)
				.FirstOrDefault();

			var deleteEvent = new DeleteEventViewModel()
			{
				Id = currEvent.Id,
				Topic = currEvent.Topic,
				Location = currEvent.Location,
			};

			return deleteEvent;
		}

		public async Task<int> DeleteEventConfirmedAsync(int eventId)
		{
			var currEvent = await dbContext
				.Events
				.FindAsync(eventId);

			currEvent.IsDeleted = true;

			await dbContext.SaveChangesAsync();

			return currEvent.Id;
		}

		public async Task<DetailsEventViewModel> DetailsAsync(int eventId)
		{
			var currEvent = await dbContext
				.Events
				.Where(e => e.IsDeleted == false && e.Id == eventId)
				.Select(e => new DetailsEventViewModel
				{
					Id = e.Id,
					Topic = e.Topic,
					Date = e.Date,
					Location = e.Location,
					Description = e.Description,
					Seats = e.Seats,
					TicketPrice = e.TicketPrice,
				})
				.FirstAsync();

			return currEvent;
		}
		public async Task EditEventAsync(int id, EventFormViewModel eventForm)
		{
			var currentEvent = await dbContext
				.Events
				.FindAsync(id);

			if (currentEvent != null)
			{
				currentEvent.Topic = eventForm.Topic;
				currentEvent.Description = eventForm.Description;
				currentEvent.Date = eventForm.Date;
				currentEvent.TicketPrice = eventForm.TicketPrice;
				currentEvent.Location = eventForm.Location;
				currentEvent.Seats = eventForm.Seats;

				await dbContext.SaveChangesAsync();
			}
		}

		public async Task<bool> EventExistsAsync(int eventId)
		{
			return await dbContext
				.Events
				.AsNoTracking()
				.AnyAsync(b => b.Id == eventId);
		}

		public async Task<EventFormViewModel> FindEventByIdAsync(int eventId)
		{
			return await dbContext
				.Events
				.Where(e => e.Id == eventId)
				.Select(e => new EventFormViewModel
				{
                    Topic = e.Topic,
                    Description = e.Description,
                    Location = e.Location,
                    Date = e.Date,
                    Seats = e.Seats,
                    TicketPrice = e.TicketPrice
                })
				.FirstAsync();
		}
	}
}
