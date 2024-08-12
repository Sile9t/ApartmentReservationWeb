using ApartmentReservationWeb.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentReservationWeb.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ILogger<CalendarController> _logger;
        private readonly IDateRepository _repository;

        public CalendarController(ILogger<CalendarController> logger, IDateRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Main()
        {
            ViewData["CalendarDates"] = _repository.GetAllDates();
            return View();
        }
    }
}
