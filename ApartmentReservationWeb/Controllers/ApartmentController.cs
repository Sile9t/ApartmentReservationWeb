using ApartmentReservationWeb.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentReservationWeb.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly ILogger<ApartmentController> _logger;
        private readonly IApartmentRepository _repository;

        public ApartmentController(ILogger<ApartmentController> logger, IApartmentRepository repository)
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
