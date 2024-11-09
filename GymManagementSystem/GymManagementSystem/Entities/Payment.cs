namespace GymManagementSystem.Entities
{
    public class Payment
    {

        public Guid PaymentId { get; set; }
        public DateTime Paymentdate { get; set; }
        public string Amount { get; set; }
        public Guid MemberId { get; set; }
        public Guid WPaymentId { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
