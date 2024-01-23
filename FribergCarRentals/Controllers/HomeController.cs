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


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Vehicles()
        {

            return View(_vehicleRepo.GetAll());
        }

        public ActionResult Details(int id)
        {
            var vehicle = _vehicleRepo.GetById(id);
            return View(vehicle);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
