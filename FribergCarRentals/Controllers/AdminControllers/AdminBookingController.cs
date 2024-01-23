using FribergCarRentals.Data.Interfaces;
using FribergCarRentals.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FribergCarRentals.Controllers.AdminControllers
{
    public class AdminBookingController : Controller
    {
        private readonly IBookingRepository _bookingRepo;
        private static Admin? _activeAdmin;

        public AdminBookingController(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        // GET: AdminBooking
        public ActionResult Index(Admin activeAdmin)
        {
            _activeAdmin = activeAdmin;
            var action = View(_bookingRepo.GetAll());
            return CheckForAdmin(action);
        }

        public ActionResult Logout()
        {
            _activeAdmin = null;
            return RedirectToAction("Logout", "Admin");
        }

        public ActionResult Details(int id) 
        {
            var booking = _bookingRepo.GetById(id);
            var action = View(booking);
            return CheckForAdmin(action);
        }

        // GET: AdminBooking/Delete/5
        public ActionResult Delete(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            var booking = _bookingRepo.GetById((int)id);
            if (booking == null)
            {
                return NotFound();
            }
            var action = View(booking);
            return CheckForAdmin(action);
        }

        // POST: AdminBooking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var booking = _bookingRepo.GetById(id);
            if (booking != null && _activeAdmin != null)
            {
                try
                {
                    _bookingRepo.Delete(id);
                }
                catch(Exception)
                {
                    return View(nameof(Error));
                }
                
            }
            return RedirectToAction(nameof(Index));
        }

        private ActionResult CheckForAdmin(ActionResult action)
        {
            if (_activeAdmin == null)
            {
                action = RedirectToAction("Login", "Admin");
            }
            return action;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
