using GymManagementSystem.Entities;
using GymManagementSystem.IRepositories;
using GymManagementSystem.IServices;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GymManagementSystem.Services
{
    public class LoginService: ILoginService
    {
        private readonly ILoginRepository _authRepository;
        private readonly IConfiguration _configuration;
        public LoginService(ILoginRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }
        //public async Task<string> Register(UserRequestModel userRequest)
        //{
        //    var req = new User
        //    {
        //        Name = userRequest.Name,
        //        Email = userRequest.Email,
        //        Role = userRequest.Role,
        //        PasswordHash = BCrypt.Net.BCrypt.HashPassword(userRequest.Password)
        //    };
        //    var user = await _authRepository.AddUser(req);
        //    var token = CreateToken(user);
        //    return token;
        //}

        public async Task<string> Login(string Id, string password)
        {
            var user = await _authRepository.GetUserById(Id);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new Exception("Wrong password.");
            }
            return CreateToken(user);
        }


        private string CreateToken(User user)
        {
            var claimsList = new List<Claim>();
            claimsList.Add(new Claim("Id", user.Id.ToString()));
            claimsList.Add(new Claim("ProfileImage", user.ProfileImage));
            claimsList.Add(new Claim("Roles", user.Roles.ToString()));


            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var credintials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                claims: claimsList,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credintials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
