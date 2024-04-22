using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheReader.Core.Contracts.Event;
using TheReader.Core.Models.Event;
using TheReader.Core.Services;
using static TheReader.Infrastructure.Constants.NotificationMessagesConstants;

namespace Bookshop___The_Reader.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService eventService;
        public EventController(IEventService _eventService)
        {
            eventService = _eventService;
        }
        public async Task<IActionResult> All()
        {
            var events = await eventService.AllAsync();

            if (events == null)
            {
                return View();
            }
            return View(events);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (!await eventService.EventExistsAsync(id))
            {
                return BadRequest();
            }
            var currentEvent = await eventService.DetailsAsync(id);

            if (currentEvent == null)
            {
                return BadRequest();
            }
            return View(currentEvent);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddEvent()
        {
            if (!User.IsInRole("Administrator"))
            {
                return Unauthorized();
            }

            var eventForm = new EventFormViewModel();

            return View(eventForm);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddEvent(EventFormViewModel eventForm)
        {
            if (!User.IsInRole("Administrator"))
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return View(eventForm);
            }

            await eventService.AddEventAsync(eventForm);
            return RedirectToAction("All", "Event");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var currBook = await eventService.FindEventByIdAsync(id);
                return View(currBook);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }

        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, EventFormViewModel eventModel)
        {
            try
            {
                await eventService.EditEventAsync(id, eventModel);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }

            TempData[SuccessMessage] = "You edited the event successfully.";
            return RedirectToAction("All", "Event");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {

            if (!await eventService.EventExistsAsync(id))
            {
                return BadRequest();
            }

            var serachEvent = eventService.DeleteEventAsync(id);

            return View(serachEvent);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            if (!await eventService.EventExistsAsync(id))
            {
                return BadRequest();
            }
            await eventService.DeleteEventConfirmedAsync(id);

            return RedirectToAction("All", "Event");
        }
        private IActionResult GeneralErrorMessage()
        {
            TempData[ErrorMessage] = "An unexpected error occurred! Please, try again.";

            return RedirectToAction("All", "Event");
        }
    }
}
