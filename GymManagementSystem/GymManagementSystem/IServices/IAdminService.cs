using GymManagementSystem.DTO.RequestDTO;
using GymManagementSystem.Entities;

namespace GymManagementSystem.IServices
{
    public interface IAdminService
    {
        Task<string> CreateMember(MemberRequestDTO memberRequestDTO);
    }
}
