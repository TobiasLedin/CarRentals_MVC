using FribergCarRentals.Models;

namespace FribergCarRentals.Data.Interfaces
{
    public interface IAdminRepository
    {
        Admin GetByEmail(string email);
        void Update(Admin admin);

    }
}
