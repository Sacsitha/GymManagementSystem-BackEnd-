namespace GymManagementSystem.DTO.Response_DTO
{
    public class AllPaymentResponse
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Reason { get; set; }
        public Guid MemberId { get; set; }
        public bool IsRefund { get; set; }
    }
}
