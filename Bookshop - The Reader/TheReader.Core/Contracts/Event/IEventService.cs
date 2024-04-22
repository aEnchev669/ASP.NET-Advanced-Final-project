using TheReader.Core.Models.Event;

namespace TheReader.Core.Contracts.Event
{
	public interface IEventService
	{
		Task<ICollection<AllEventViewModel>> AllAsync();

		Task<bool> EventExistsAsync(int eventId);
		Task<EventFormViewModel> FindEventByIdAsync(int eventId);
		Task<DetailsEventViewModel> DetailsAsync(int eventId);
		Task<int> AddEventAsync(EventFormViewModel eventForm);
		Task EditEventAsync(int id, EventFormViewModel eventForm);
		DeleteEventViewModel DeleteEventAsync(int eventId);
		Task<int> DeleteEventConfirmedAsync(int eventId);
	}
}
