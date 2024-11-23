using GymManagementSystem.Entities;

namespace GymManagementSystem.DTO.RequestDTO
{
    public class SkippedPaymentRequestDTO
    {
        public DateTime EndtDate { get; set; }
        public string Reason { get; set; }
        public Guid MemberId { get; set; }
        public Guid ProgramId { get; set; }
    }
}
