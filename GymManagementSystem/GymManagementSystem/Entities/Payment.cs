using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Entities
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Amount { get; set; }
        public Guid? MemberId { get; set; }
        public Member? member { get; set; }
        public Guid? ProgramPaymentId {  get; set; }
        public ProgramPayment? programPayment { get; set; }
    }
}
