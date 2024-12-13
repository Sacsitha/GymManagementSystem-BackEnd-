using GymManagementSystem.IServices;
using GymManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        [HttpGet("Program-Report")]
        public async Task<IActionResult> ProgramReport()
        {
            try
            {
                var data = await _reportService.GetEnrollmentCount();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Annual-Financial-Report")]
        public async Task<IActionResult> AnnualFinancialIncome(int? year)
        {
            try
            {
                var data = await _reportService.AnnualFinancialIncome(year);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Member-Report")]
        public async Task<IActionResult> MemberReport()
        {
            try
            {
                var data = await _reportService.MemberReport();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Monthly-Financial-Report")]
        public async Task<IActionResult> MonthlyFinancialReport(int month)
        {
            try
            {
                var data = await _reportService.MonthlyFinancialReport(month);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
