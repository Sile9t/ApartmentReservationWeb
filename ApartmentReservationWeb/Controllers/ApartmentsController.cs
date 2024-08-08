using ApartmentReservationWeb.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentReservationWeb.Controllers
{
    public class ApartmentsController : Controller
    {
        private readonly ILogger<ApartmentsController> _logger;
        private readonly IApartmentRepository _repository;

        public ApartmentsController(ILogger<ApartmentsController> logger, IApartmentRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Main()
        {
            ViewData["apartmentList"] = _repository.GetAllApartments();
            return View();
        }
    }
}
