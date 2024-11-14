using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Entities
{
    public class SubscriptionPayment
    {
        public Guid Id { get; set; }
        [Required]
        public string PaymentType { get; set; }
        public int PaymentDate { get; set; }
        public bool UserCanPay { get; set; }
        public Guid SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
        public ICollection<ProgramPayment>? ProgramPayments { get; set; }

    }
}
