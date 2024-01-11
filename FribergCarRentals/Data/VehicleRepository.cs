using FribergCarRentals.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRentals.Data
{
    public class VehicleRepository : IVehicle
    {
        private readonly ApplicationDbContext _applicationDbContext;

        //Constructor taking in ApplicationDbContext)
        public VehicleRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return _applicationDbContext.Vehicles.OrderBy(x => x.VehicleId);
        }

        public Vehicle getById(int id)
        {
            return _applicationDbContext.Vehicles.FirstOrDefault(x => x.VehicleId == id);      
        }

       
    }
}
