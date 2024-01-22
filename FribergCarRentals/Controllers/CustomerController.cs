using FribergCarRentals.Data.Interfaces;
using FribergCarRentals.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace FribergCarRentals.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IVehicleRepository _vehicleRepo;
        private readonly IBookingRepository _bookingRepo;
        private static Customer? _activeCustomer;


        public CustomerController(ICustomerRepository customerRepository, IVehicleRepository vehicleRepo, IBookingRepository bookingRepo)
        {
            _customerRepo = customerRepository;
            _vehicleRepo = vehicleRepo;
            _bookingRepo = bookingRepo;
        }


        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerController
        public ActionResult Login()
        {
            return View();
        }

        // POST: CustomerController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            var customer = _customerRepo.GetByEmail(email);
            if (customer == null)
            {
                return View();      //TODO: Error message
            }
            if (customer.Password == password)
            {
                _activeCustomer = customer;
            }
            //If a vehicleId string is present in TempData, continue the booking-process. If no, go to Index/Customer.
            if (TempData.ContainsKey("VehicleId"))
            {
                string vehicleIdString = TempData["VehicleId"].ToString();
                //var vehicleId = int.Parse(vehicleIdString);

                //Return vehicleIdString to BookingCreate
                TempData["VehicleId"] = vehicleIdString;
                return RedirectToAction("BookingCreate", "Customer");
            }
            else
            {
                return RedirectToAction("BookingOverview", "Customer");
            }
        }

        public ActionResult Logout()
        {
            _activeCustomer = null;
            return RedirectToAction("Index", "Home");
        }

        // GET: CustomerController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        public ActionResult BookingOverview()
        {
            var action = View(_bookingRepo.GetAll());
            return CheckForCustomer(action);
        }

        public ActionResult VehicleOverview()
        {
            var action = View(_vehicleRepo.GetAll());
            return CheckForCustomer(action);
        }


        // GET: CustomerController/Create
        public ActionResult BookingCreate(int id)
        {
            if (_activeCustomer == null)
            {
                //Forward vehicleId to login action if there is no logged in customer.
                TempData["VehicleId"] = id.ToString();
                return RedirectToAction("Login", "Customer");
            }
            if (TempData.ContainsKey("VehicleId"))
            {
                string vehicleIdString = TempData["VehicleId"].ToString();
                id = int.Parse(vehicleIdString);
            }
            var vehicle = _vehicleRepo.GetById(id);
            Booking booking = new()
            {
                Vehicle = vehicle,
                
                Customer = _activeCustomer,
                
                BookingStart = DateTime.Now,
                BookingEnd = DateTime.Now
            };
            return View(booking);
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookingCreate(Booking booking)
        {
            booking.Vehicle = _vehicleRepo.GetById(booking.VehicleId);
            booking.Customer = _customerRepo.GetById(booking.CustomerId);

            ModelState.Remove("Vehicle");
            ModelState.Remove("Customer");
            if (ModelState.IsValid && _activeCustomer != null)
            {
                _bookingRepo.Create(booking);

                //return RedirectToAction("Create", "CustomerBooking", booking);
            }
            return RedirectToAction("BookingResult", new { id = booking.BookingId });
        }

        public ActionResult BookingResult(int id)
        {
            
            if (id != 0)
            {
                ViewBag.Result = "Booking Successfully created!";
                var booking = _bookingRepo.GetById(id);
                return View(booking);
            }
            else
            {
                ViewBag.Result = "There was an issue creating the booking!";
                return View();
            }
        }


        // GET: CustomerController/Delete/5
        public ActionResult BookingDelete(int id)
        {
            var booking = _bookingRepo.GetById(id);

            var action = View(booking);
            return CheckForCustomer(action);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("BookingDelete")]
        public ActionResult BookingDeleteConfirmation(int id)
        {
            try
            {
                _bookingRepo.Delete(id);
            }
            catch
            {
                return View();
            }
            return RedirectToAction("BookingOverview");
        }

        private ActionResult CheckForCustomer(ActionResult action)
        {
            if (_activeCustomer == null)
            {
                action = RedirectToAction(nameof(Login));
            }
            return action;
        }
    }
}
