using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Entities
{
    public class SkippedPayment
    {
        [Key]
        public Guid SkippedPaymentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }
        public string Reason { get; set; }
        public Guid MemberId { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
