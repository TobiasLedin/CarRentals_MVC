using FribergCarRentals.Data.Interfaces;
using FribergCarRentals.Models;
using Microsoft.AspNetCore.Mvc;

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

        // GET: AdminBooking/Delete/5
        public ActionResult Delete(int? id)
        {
            Booking? booking = null;
            var action = View(booking);
            if (id == null)
            {
                return NotFound();
            }
            booking = _bookingRepo.GetById((int)id);
            if (booking == null)
            {
                return NotFound();
            }
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
                _bookingRepo.Delete(id);
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
    }
}
