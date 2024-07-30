using ApartmentReservationWeb.Abstractions;
using ApartmentReservationWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ApartmentReservationWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApartmentRepository _apartmentRepository;

        public HomeController(ILogger<HomeController> logger, IApartmentRepository apartmentRepository)
        {
            _logger = logger;
            _apartmentRepository = apartmentRepository;
        }

        public IActionResult Main()
        {
            ViewData["apartmentList"] = _apartmentRepository.GetAllApartments();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
