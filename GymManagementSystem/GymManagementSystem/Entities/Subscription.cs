using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Entities
{
    public class Subscription
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Duration { get; set; }
        public ICollection<Program>? Programs { get; set; }
        public ICollection<SubscriptionPayment>? SubscriptionPayments { get; set; }
        //public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
