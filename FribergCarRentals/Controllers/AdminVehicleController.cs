using FribergCarRentals.Data.Interfaces;
using FribergCarRentals.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace FribergCarRentals.Controllers
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
            if (_activeAdmin == null)
            {
                RedirectToAction("Login", "Admin");
            }
            return View(_vehicleRepo.GetAll());
        }

        public ActionResult Logout()
        {
            _activeAdmin = null;
            return RedirectToAction("Logout", "Admin");
        }

        // GET: AdminVehicle/Create
        public ActionResult Create()
        {
            if (_activeAdmin == null)
            {
                RedirectToAction("Login", "Admin");
            }
            return View();
        }

        // POST: AdminVehicle/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("VehicleId,Brand,Model,Year,DailyRate")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _vehicleRepo.Create(vehicle);

                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: AdminVehicle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (_activeAdmin == null)
            {
                RedirectToAction("Login", "Admin");
            }
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = _vehicleRepo.GetById((int)id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: AdminVehicle/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("VehicleId,Brand,Model,Year,DailyRate")] Vehicle vehicle)
        {
            if (id != vehicle.VehicleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _vehicleRepo.Update(vehicle);
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: AdminVehicle/Delete/5
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

            var vehicle = _vehicleRepo.GetById((int)id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: AdminVehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var vehicle = _vehicleRepo.GetById(id);
            if (vehicle != null)
            {
                _vehicleRepo.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
