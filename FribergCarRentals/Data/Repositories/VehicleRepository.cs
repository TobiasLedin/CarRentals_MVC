using FribergCarRentals.Data.Interfaces;
using FribergCarRentals.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRentals.Data.Repositories
{
    public class VehicleRepository : IVehicle
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public VehicleRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Create(Vehicle vehicle)
        {
            try
            {
                _applicationDbContext.Vehicles.Add(vehicle);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

            }
            
        }

        public void Delete(int id)
        {
            var vehicle = _applicationDbContext.Vehicles.Find(id);
            try
            {
                _applicationDbContext.Vehicles.Remove(vehicle);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception) 
            { 

            }
        }

        public IEnumerable<Vehicle> GetAll()
        {
            IEnumerable<Vehicle> vehicles;
            try
            {
                if (!_applicationDbContext.Vehicles.Any())
                {
                    vehicles = Enumerable.Empty<Vehicle>();
                }
                else
                {
                    vehicles = _applicationDbContext.Vehicles.ToList();
                }
                return vehicles;
            }
            catch(Exception)
            {
                return null;    //TODO: Null-return
            }
        }

        public Vehicle GetById(int id)
        {
            if (!_applicationDbContext.Vehicles.Any())
            {
                return null;
            }
            else
            {
                var vehicle = _applicationDbContext.Vehicles.Find(id);  //TODO: Utvärdera Find, alt byt till FirstOrDefault().
                return vehicle;
            }
                
        }

        public void Update(Vehicle vehicle)
        {
            try
            {
                _applicationDbContext.Vehicles.Update(vehicle);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

            }
        }
    }
}
