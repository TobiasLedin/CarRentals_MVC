using FribergCarRentals.Data.Interfaces;
using FribergCarRentals.Models;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRentals.Controllers
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
            if (_activeAdmin == null)
            {
                RedirectToAction("Login", "Admin");
            }
            return View(_bookingRepo.GetAll());
        }

        public ActionResult Logout()
        {
            _activeAdmin = null;
            return RedirectToAction("Logout", "Admin");
        }


        // GET: AdminBooking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (_activeAdmin == null)
            {
                RedirectToAction("Login", "Admin");
            }
            if (id == null)
            {
                return NotFound();
            }

            var booking = _bookingRepo.GetById((int)id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: AdminBooking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var booking = _bookingRepo.GetById(id);
            if (booking != null)
            {
                _bookingRepo.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
