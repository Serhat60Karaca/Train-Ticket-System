using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TicketApp.Models;
using TicketApp.Repositories;

namespace TicketApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IPassengerRepository _passengerRepository;
        public HomeController(ILogger<HomeController> logger, IPassengerRepository passengerRepository)
        {
            _logger = logger;
            _passengerRepository = passengerRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Passenger passenger)
        {
            _passengerRepository.registerPassenger(passenger);
            return Content("successful!!");
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