using GymManagementSystem.DTO.RequestDTO;
using GymManagementSystem.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpPost("Add-Payment")]
        public async Task<IActionResult> AddPayment(PaymentRequestDTO payment)
        {
            try
            {
                var data = await _paymentService.AddPayment(payment);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get-Member-Payment/{memberId}")]
        public async Task<IActionResult> GetMemberPayment(Guid memberId)
        {
            try
            {
                var data = await _paymentService.GetMemberPayments(memberId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllPayments")]
        public async Task<IActionResult> GetAllPayments()
        {
            try
            {
                var data = await _paymentService.GetAllPayments();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add-Refund")]
        public async Task<IActionResult> AddRefund(RefundRequestDTO payment)
        {
            try
            {
                var data = await _paymentService.AddRefund(payment);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get-Member-Refund/{memberId}")]
        public async Task<IActionResult> GetMemberRefund(Guid memberId)
        {
            try
            {
                var data = await _paymentService.GetMemberRefunds(memberId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllRefunds")]
        public async Task<IActionResult> GetAllRefunds()
        {
            try
            {
                var data = await _paymentService.GetAllRefunds();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add-Skipped-Payment")]
        public async Task<IActionResult> AddSkippedPayment(SkippedPaymentRequestDTO payment)
        {
            try
            {
                var data = await _paymentService.AddSkippedPayment(payment);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get-Member-Skipped-Payment/{memberId}")]
        public async Task<IActionResult> GetMemberSkippedPayment(Guid memberId)
        {
            try
            {
                var data = await _paymentService.GetMemberSkippedPayment(memberId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllSkippedPayment")]
        public async Task<IActionResult> GetAllPaGetAllSkippedPaymentyments()
        {
            try
            {
                var data = await _paymentService.GetAllSkippedPayment();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get-Overdue-Member-Details")]
        public async Task<IActionResult> GetOverDueMembers()
        {
            try
            {
                var data = await _paymentService.GetOverDueMembers();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
