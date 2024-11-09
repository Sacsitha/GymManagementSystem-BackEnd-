using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Entities
{
    public class ProgramPayment
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public bool Status { get; set; }=true;
        public Guid? ProgramId { get; set; }
        public Program? program { get; set; }
        public ICollection<Payment>? Payments { get; set; }
        public ICollection<SubscriptionPayment>? SubscriptionPayments { get; set; }
    }
}
