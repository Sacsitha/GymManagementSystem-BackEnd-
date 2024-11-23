namespace GymManagementSystem.DTO.RequestDTO
{
    public class RefundRequestDTO
    {
        public decimal Amount { get; set; }
        public string Reason { get; set; }
        public Guid MemberId { get; set; }
    }
}
