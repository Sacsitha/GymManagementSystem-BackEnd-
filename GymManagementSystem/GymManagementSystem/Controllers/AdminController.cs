using GymManagementSystem.DTO.RequestDTO;
using GymManagementSystem.Entities;
using GymManagementSystem.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly IProgramService _programService;

        public AdminController(IProgramService programService, IMemberService memberService)
        {
            _memberService = memberService;
            _programService = programService;
        }

        [HttpPost("Add User")]
        public async Task<IActionResult> CreateUser(MemberRequestDTO memberRequestDTO)
        {
            try
            {
                var data = _memberService.CreateMember (memberRequestDTO);
                return Ok(data);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add Admin")]
        public async Task<IActionResult> CreateAdmin(AdminRequestDTO adminRequestDTO)
        {
            try
            {
                var data = _memberService.CreateAdmin(adminRequestDTO);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add Enrollment")]
        public async Task<IActionResult> CreateEnrollment(EnrollmentRequestDTO enrollment)
        {
            try
            {
                var data = _memberService.AddEnrollment(enrollment);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Get-All-Members")]
        public async Task<IActionResult> GetAllMembers( )
        {
            try
            {
                var data = _memberService.GetAllMemberDetails();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get-Single-Member{id}")]
        public async Task<IActionResult> GetSingleMember(Guid id)
        {
            try
            {
                var data = _memberService.GetSingleMember(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get-Member-Enrolled-Programs{memberId}")]
        public async Task<IActionResult> GetEnrolledPrograms(Guid memberId)
        {
            try
            {
                var data = _memberService.GetMemberEnrolledPrograms(memberId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get-Member-Enrollable-Programs{memberId}")]
        public async Task<IActionResult> GetEnrollablePrograms(Guid memberId)
        {
            try
            {
                var data = _memberService.GetEnrollablePrograms(memberId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
