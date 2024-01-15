using FribergCarRentals.Models;

namespace FribergCarRentals.Data.Interfaces
{
    public interface IVehicle
    {
        void Create(Vehicle vehicle);
        Vehicle GetById(int id);
        IEnumerable<Vehicle> GetAll();
        void Update(Vehicle vehicle);
        void Delete(int id);

    }
}
