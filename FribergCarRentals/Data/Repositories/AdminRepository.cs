using FribergCarRentals.Data.Interfaces;
using FribergCarRentals.Models;

namespace FribergCarRentals.Data.Repositories
{
    public class AdminRepository : IAdmin
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AdminRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public Admin GetById(int id)
        {
            var admin = _applicationDbContext.Admins.Find(id);
            return admin;
        }

        public void Update(Admin admin)
        {
            _applicationDbContext.Admins.Update(admin);
            _applicationDbContext.SaveChanges();
        }
    }
}
