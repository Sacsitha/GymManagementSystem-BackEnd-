using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Entities
{
    public class SubscriptionPayment
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string PaymentType { get; set; }
        public Guid? SubscriptionId { get; set; }
        public Subscription? subscription { get; set; }
        public ICollection<ProgramPayment> ProgramPayments { get; set; }

    }
}
