using FribergCarRentals.Data.Interfaces;
using FribergCarRentals.Models;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRentals.Controllers.AdminControllers
{
    public class AdminVehicleController : Controller
    {
        private readonly IVehicleRepository _vehicleRepo;
        private static Admin? _activeAdmin;

        public AdminVehicleController(IVehicleRepository vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;
        }

        // GET: AdminVehicle
        public ActionResult Index(Admin activeAdmin)
        {
            _activeAdmin = activeAdmin;
            var action = View(_vehicleRepo.GetAll());
            return CheckForAdmin(action);
        }

        public ActionResult Logout()
        {
            _activeAdmin = null;
            return RedirectToAction("Logout", "Admin");
        }

        public ActionResult Details(int id)
        {
            var vehicle = _vehicleRepo.GetById(id);
            var action = View(vehicle);
            return CheckForAdmin(action);
        }

        // GET: AdminVehicle/Create
        public ActionResult Create()
        {
            var action = View();
            return CheckForAdmin(action);
        }

        // POST: AdminVehicle/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid && _activeAdmin != null)
            {
                _vehicleRepo.Create(vehicle);
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: AdminVehicle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vehicle = _vehicleRepo.GetById((int)id);
            if (vehicle == null)
            {
                return NotFound();
            }
            var action = View(vehicle);
            return CheckForAdmin(action);
        }

        // POST: AdminVehicle/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Vehicle vehicle)
        {
            if (id != vehicle.VehicleId)
            {
                return NotFound();
            }
            if (ModelState.IsValid && _activeAdmin != null)
            {
                try
                {
                    _vehicleRepo.Update(vehicle);
                }
                catch (Exception)
                {
                    return RedirectToAction("Error");       //TODO: Consistency in error catching?
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: AdminVehicle/Delete/5
        public ActionResult Delete(int? id)
        {
            
            
            if (id == null)
            {
                return NotFound();
            }
            var vehicle = _vehicleRepo.GetById((int)id);
            if (vehicle == null)
            {
                return NotFound();
            }
            var action = View(vehicle);
            return CheckForAdmin(action);
        }

        // POST: AdminVehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var vehicle = _vehicleRepo.GetById(id);
            if (vehicle != null && _activeAdmin != null)
            {
                _vehicleRepo.Delete(id);
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
