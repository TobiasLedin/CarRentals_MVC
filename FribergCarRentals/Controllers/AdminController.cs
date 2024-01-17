using FribergCarRentals.Data.Interfaces;
using FribergCarRentals.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FribergCarRentals.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminRepository _adminRepo;
        private readonly IVehicleRepository _vehicleRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IBookingRepository _bookingRepo;
        private static Admin? _activeAdmin;

        public AdminController(IAdminRepository adminRepo, IVehicleRepository vehicleRepo, ICustomerRepository customerRepo, IBookingRepository bookingRepo)
        {
            _adminRepo = adminRepo;
            _vehicleRepo = vehicleRepo;
            _customerRepo = customerRepo;
            _bookingRepo = bookingRepo;
        }

        // Admininistrator login screen redirect
        public ActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            var adminObj = _adminRepo.GetByEmail(email);
            if (adminObj == null)
            {
                return View();      //TODO: Error message
            }
            if (adminObj.Password == password)
            {
                _activeAdmin = adminObj;
                return RedirectToAction(nameof(Overview));
            }

            return View();

        }

        public ActionResult Logout()
        {
            
            _activeAdmin = null;
            return RedirectToAction(nameof(Login));  //TODO: Logout message?
        }

        public ActionResult Overview()
        {
            if (_activeAdmin == null)
            {
                return RedirectToAction(nameof(Login));
            }
            else
            {
                return View(_activeAdmin);
            }
        }

        public ActionResult VehicleOverview()
        {
            
            if (_activeAdmin == null)
            {
                return RedirectToAction(nameof(Login));
            }
            else
            {
                return RedirectToAction("Index", "AdminVehicle", _activeAdmin);
            }
        }

        public ActionResult BookingOverview()
        {
            if (_activeAdmin == null)
            {
                return RedirectToAction(nameof(Login));
            }
            else
            {
                return RedirectToAction("Index", "AdminBooking", _activeAdmin);
            }
        }

        public ActionResult CustomerOverview()
        {
            
            if (_activeAdmin == null)
            {
                return RedirectToAction(nameof(Login));
            }
            else
            {
                return RedirectToAction("Index", "AdminCustomer", _activeAdmin);
            }
        }

    }
}

