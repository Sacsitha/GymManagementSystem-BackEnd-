namespace GymManagementSystem.Entities
{
    public class RefundPayment
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Reason { get; set; }
        public Guid MemberId { get; set; }
        public Member Member { get; set; }
    }
}
