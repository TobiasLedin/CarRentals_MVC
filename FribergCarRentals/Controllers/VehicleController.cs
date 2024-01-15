using FribergCarRentals.Data;
using FribergCarRentals.Data.Interfaces;
using FribergCarRentals.Data.Repositories;
using FribergCarRentals.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRentals.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicle _vehicleRepository;

        public VehicleController(IVehicle vehicleRepository)
        {
            _vehicleRepository = vehicleRepository; 
        }


        // GET: VehicleController
        public ActionResult Index()
        {
            return View(_vehicleRepository.GetAll());
        }

        // GET: VehicleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("VehicleId, Brand, Model, Year, DailyRate")] Vehicle vehicle)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    _vehicleRepository.Create(vehicle);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || _vehicleRepository.GetAll() == null)
            {
                return NotFound();
            }
            var vehicle = _vehicleRepository.GetById((int) id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: VehicleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Vehicle vehicle)
        {
            if (id != vehicle.VehicleId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _vehicleRepository.Update(vehicle);
                }
                catch (Exception)
                {
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: VehicleController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || _vehicleRepository.GetAll() == null)
            {
                return NotFound();
            }
            var vehicle = _vehicleRepository.GetById((int)id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: VehicleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Vehicle vehicle)
        {
            if (id != vehicle.VehicleId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _vehicleRepository.Delete(vehicle);
                }
                catch (Exception)
                {
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

       
    }
}
