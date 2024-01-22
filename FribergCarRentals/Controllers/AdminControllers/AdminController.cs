using FribergCarRentals.Data.Interfaces;
using FribergCarRentals.Models;
using FribergCarRentals.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FribergCarRentals.Controllers.AdminControllers
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
            var admin = _adminRepo.GetByEmail(email);
            if (admin == null)
            {
                return View();      //TODO: Error message
            }
            if (admin.Password == password)
            {
                _activeAdmin = admin;
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
            OverviewVM overviewVM = new()
            {
                DeliveryToday = _bookingRepo.GetAll().Where(x => x.BookingStart == DateTime.Now).Count(),
                DeliveryUpcoming = _bookingRepo.GetAll().Where(x => x.BookingStart > DateTime.Now).Count(),
                FleetSize = _vehicleRepo.GetAll().Count(),
                CustomerStock = _customerRepo.GetAll().Count()
            };
            var action = View(overviewVM);
            return CheckForAdmin(action);
        }

        public ActionResult VehicleOverview()
        {
            var action = RedirectToAction("Index", "AdminVehicle", _activeAdmin);
            return CheckForAdmin(action);
        }

        public ActionResult BookingOverview()
        {
            var action = RedirectToAction("Index", "AdminBooking", _activeAdmin);
            return CheckForAdmin(action);
        }

        public ActionResult CustomerOverview()
        {
            var action = RedirectToAction("Index", "AdminCustomer", _activeAdmin);
            return CheckForAdmin(action);
        }

        private ActionResult CheckForAdmin(ActionResult action)
        {
            if (_activeAdmin == null)
            {
                action = RedirectToAction(nameof(Login));
            }
            return action;
        }
    }
}

