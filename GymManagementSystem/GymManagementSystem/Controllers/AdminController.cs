using GymManagementSystem.DTO.RequestDTO;
using GymManagementSystem.Entities;
using GymManagementSystem.IServices;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize (Roles= "Admin")]
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
        [HttpPost("Add-Program")]
        public async Task<IActionResult> AddProgram(ProgramRequestDTO program)
        {
            try
            {
                var data = _programService.AddProgram(program);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add-Subscription")]
        public async Task<IActionResult> AddSubscription(SubscriptionRequestDTO subscription)
        {
            try
            {
                var data = _programService.AddSubscription(subscription);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add-Subscription-Payment/{subId}")]
        public async Task<IActionResult> AddSubscriptionPayment(Guid subId,SubscriptionPaymentRequestDTO subscriptionPayment)
        {
            try
            {
                var data = _programService.AddSubscriptionPayment(subId,subscriptionPayment);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add-Program-Subscription")]
        public async Task<IActionResult> AddSubscribedProgram(SubscribedProgramRequestDTO subProgram)
        {
            try
            {
                var data = _programService.AddSubscribedProgram(subProgram);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add-Program-Subscription/{subscriptionId}")]
        public async Task<IActionResult> AddSubscribedProgramList(Guid subscriptionId, List<Guid> programIds)
        {
            try
            {
                var data = _programService.AddSubscribedProgramList(subscriptionId, programIds);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddProgramPayment")]
        public async Task<IActionResult> AddProgramPayment(ProgramPaymentRequestDTO programPayment)
        {
            try
            {
                var data = _programService.AddProgramPayment(programPayment);
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
        [HttpGet("Get-Single-Program{id}")]
        public async Task<IActionResult> GetSingleProgram(Guid id)
        {
            try
            {
                var data = _programService.GetSingleProgram(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllPrograms")]
        public async Task<IActionResult> GetAllPrograms()
        {
            try
            {
                var data = _programService.GetAllPrograms();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetSingleSubscription{id}")]
        public async Task<IActionResult> GetSingleSubscription(Guid id)
        {
            try
            {
                var data = _programService.GetSingleSubscription(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllSubscriptions")]
        public async Task<IActionResult> GetAllSubscriptions()
        {
            try
            {
                var data = _programService.GetAllSubscriptions();
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


        [HttpPut("Update-Member{memberId}")]
        public async Task<IActionResult> UpdateMember(Guid memberId,MemberRequestDTO memberRequestDTO)
        {
            try
            {
                var data = _memberService.UpdateMember(memberId,memberRequestDTO);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateProgram{Id}")]
        public async Task<IActionResult> UpdateProgram(Guid Id, ProgramRequestDTO programRequestDTO)
        {
            try
            {
                var data = _programService.UpdateProgram(Id, programRequestDTO);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateProgramPayment{Id}")]
        public async Task<IActionResult> UpdateProgramPayment(Guid Id, decimal Amount)
        {
            try
            {
                var data = _programService.UpdateProgramPayment(Id, Amount);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateSubscription{Id}")]
        public async Task<IActionResult> UpdateSubscription(Guid Id, SubscriptionRequestDTO subscription)
        {
            try
            {
                var data = _programService.UpdateSubscription(Id, subscription);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateSubscriptionPayment{Id}")]
        public async Task<IActionResult> UpdateSubscriptionPayment(Guid Id, SubscriptionPaymentRequestDTO subPayment)
        {
            try
            {
                var data = _programService.UpdateSubscriptionPayment(Id, subPayment);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete-Member{memberId}")]
        public async Task<IActionResult> DeleteMember(Guid memberId)
        {
            try
            {
                var data = _memberService.DeleteMember(memberId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteProgram{Id}")]
        public async Task<IActionResult> DeleteProgram(Guid Id)
        {
            try
            {
                var data = _programService.DeleteProgram(Id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteSubscription{Id}")]
        public async Task<IActionResult> DeleteSubscription(Guid Id)
        {
            try
            {
                var data = _programService.DeleteSubscription(Id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteSubscriptionPayment{Id}")]
        public async Task<IActionResult> DeleteSubscriptionPayment(Guid Id)
        {
            try
            {
                var data = _programService.DeleteSubscriptionPayment(Id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteSubscribedProgram{subscribeId},{programId}")]
        public async Task<IActionResult> DeleteSubscribedProgram(Guid subscribeId, Guid programId)
        {
            try
            {
                var data = _programService.DeleteSubscribedProgram(subscribeId,programId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete-Enrollment{memberId},{programId}")]
        public async Task<IActionResult> DeleteProgram(Guid memberId,Guid programId)
        {
            try
            {
                var data = _memberService.DeleteEnrollment(memberId,programId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
