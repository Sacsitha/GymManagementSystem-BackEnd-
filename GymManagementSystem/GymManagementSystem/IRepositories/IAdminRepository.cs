using GymManagementSystem.Entities;

namespace GymManagementSystem.IRepositories
{
    public interface IAdminRepository
    {
        User CreateUser(User user);
        Task<List<Member>> GetAllMembers();
        Task<Member> GetMember(Guid id);
    }

}
