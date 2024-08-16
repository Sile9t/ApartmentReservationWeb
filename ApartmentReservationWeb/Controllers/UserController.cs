using ApartmentReservationWeb.Dtos;
using ApartmentReservationWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentReservationWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;

        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register([Bind("ReturnUrl")] string? ReturnUrl)
        {
            if (!String.IsNullOrEmpty(ReturnUrl))
                ViewData["ReturnUrl"] = ReturnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register([FromForm] UserDto userDto, [Bind("ReturnUrl")] string? ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                _userService.AddUser(userDto);

                if (!String.IsNullOrEmpty(ReturnUrl))
                    return Redirect(ReturnUrl);
                else
                    return RedirectToAction("Main", "Home");
            }
            return View(userDto);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([Bind("Phone, Password")] LoginDto loginDto, [Bind("ReturnUrl")] string? ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var userId = _userService.CheckUser(loginDto, out int? Id);

                if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else return RedirectToAction("Main", "Home");
            }

            return View(loginDto);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? ResurnUrl = null)
        {
            if (!String.IsNullOrEmpty(ResurnUrl))
                ViewData["ReturnUrl"] = ResurnUrl;
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Main()
        {
            return View();
        }
    }
}
