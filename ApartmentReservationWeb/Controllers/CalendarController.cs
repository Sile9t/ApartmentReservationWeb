﻿using ApartmentReservationWeb.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentReservationWeb.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ILogger<CalendarController> _logger;
        private readonly IDateRepository _repository;
        private readonly IApartmentRepository _apartRepo;
        public CalendarController(ILogger<CalendarController> logger,
            IDateRepository repository, IApartmentRepository apartRepo)
        {
            _logger = logger;
            _repository = repository;
            _apartRepo = apartRepo;
        }

        public IActionResult Main(string? userId = null)
        {
            ViewData["aparts"] = _apartRepo.GetApartmentsByOwnerId(userId);
            ViewData["calendarDates"] = _repository.GetAllDates();
            return View();
        }
    }
}
