using GymManagementSystem.DTO.RequestDTO;
using GymManagementSystem.Entities;
using GymManagementSystem.IRepositories;
using GymManagementSystem.IServices;

namespace GymManagementSystem.Services
{
    public class AdminService: IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        //Member management
        public async Task<string> CreateMember(MemberRequestDTO memberRequestDTO)
        {
            var newUser = new User()
            {
                Id = memberRequestDTO.UserId,
                Password = memberRequestDTO.FirstName + memberRequestDTO.Age + memberRequestDTO.Height,
                ProfileImage = memberRequestDTO.ProfileImage,
                Roles = Roles.Member,
                Member= new Member()
                {
                    FirstName = memberRequestDTO.FirstName,
                    LastName = memberRequestDTO.LastName,
                    Email = memberRequestDTO.Email,
                    DOB = memberRequestDTO.DOB,
                    ContactNo = memberRequestDTO.ContactNo,
                    Address = memberRequestDTO.Address,
                    Age = memberRequestDTO.Age,
                    Height = memberRequestDTO.Height,
                    Weight = memberRequestDTO.Weight,
                    Gender = memberRequestDTO.Gender,
                    NicNo = memberRequestDTO.NicNo,
                    CreatedDate = DateTime.Now,
                    MemberStatus = true,
                }
                };
            var data = _adminRepository.CreateUser(newUser);
            if (data is User)
            {
                return "User Added Successfully";
            }
            else
            {
                return "Please try again";
            }
        }
         
}
}
