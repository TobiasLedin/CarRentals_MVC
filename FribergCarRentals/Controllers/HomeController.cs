using FribergCarRentals.Data.Interfaces;
using FribergCarRentals.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FribergCarRentals.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVehicleRepository _vehicleRepo;

        public HomeController(IVehicleRepository vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Vehicles()
        {

            return View(_vehicleRepo.GetAll());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
