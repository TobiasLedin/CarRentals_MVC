using FribergCarRentals.Models;

namespace FribergCarRentals.Data.Interfaces
{
    public interface IVehicle
    {
        Vehicle GetById(int id);
        IEnumerable<Vehicle> GetAll();

    }
}
