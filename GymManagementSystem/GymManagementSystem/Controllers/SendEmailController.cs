using GymManagementSystem.Entities;
using GymManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController(SendEmailService _sendmailService) : ControllerBase
    {
        [HttpPost("Send-Mail")]
        public async Task<IActionResult> Sendmail(SendMailRequest sendMailRequest)
        {
            var res = await _sendmailService.Sendmail(sendMailRequest).ConfigureAwait(false);
            return Ok(res);
        }
    }
}
