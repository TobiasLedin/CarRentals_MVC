using FribergCarRentals.Data.Interfaces;
using FribergCarRentals.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRentals.Data.Repositories
{
    public class VehicleRepository : IVehicle
    {
        private readonly ApplicationDbContext _applicationDbContext;

        //Constructor taking in ApplicationDbContext)
        public VehicleRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return _applicationDbContext.Vehicles.OrderBy(x => x.VehicleId);
        }

        public Vehicle GetById(int id)
        {
            return _applicationDbContext.Vehicles.FirstOrDefault(x => x.VehicleId == id);
        }
    }
}
