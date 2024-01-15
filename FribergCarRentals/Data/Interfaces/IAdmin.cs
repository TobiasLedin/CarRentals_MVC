using FribergCarRentals.Models;

namespace FribergCarRentals.Data.Interfaces
{
    public interface IAdmin
    {
        Admin GetById(int id);
        void Update(Admin admin);

    }
}
