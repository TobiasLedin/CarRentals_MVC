using FribergCarRentals.Models;

namespace FribergCarRentals.Data
{
    public interface IVehicle
    {
        Vehicle getById(int id);
        IEnumerable<Vehicle> GetAll();

    }
}
