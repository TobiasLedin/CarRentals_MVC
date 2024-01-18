using FribergCarRentals.Data.Interfaces;
using FribergCarRentals.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRentals.Controllers
{
    public class AdminCustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepo;
        private static Admin? _activeAdmin;

        public AdminCustomerController(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        // GET: AdminCustomer
        public ActionResult Index(Admin activeAdmin)
        {
            _activeAdmin = activeAdmin;
            if (_activeAdmin == null)
            {
                RedirectToAction("Login", "Admin");
            }
            return View(_customerRepo.GetAll());
        }

        public ActionResult Logout()
        {
            _activeAdmin = null;
            return RedirectToAction("Logout", "Admin");
        }

        // GET: AdminCustomer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminCustomer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("CustomerId,FirstName,LastName,Email,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerRepo.Create(customer);

                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: AdminCustomer/Edit/5
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

            var customer = _customerRepo.GetById((int)id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: AdminCustomer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("CustomerId,FirstName,LastName,Email,Password")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _customerRepo.Update(customer);
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: AdminCustomer/Delete/5
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

            var customer = _customerRepo.GetById((int)id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: AdminCustomer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var customer = _customerRepo.GetById(id);
            if (customer != null)
            {
                _customerRepo.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
