namespace GymManagementSystem.DTO.Response_DTO
{
    public class SkippedPaymentResponseDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public Guid MemberId { get; set; }
        public string ProgramName { get; set; }
    }
}
