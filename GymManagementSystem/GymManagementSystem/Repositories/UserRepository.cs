using GymManagementSystem.DBContext;
using GymManagementSystem.IRepositories;

namespace GymManagementSystem.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
