using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Entities
{
    public class Subscription
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Duration { get; set; }
        public DateTime Date { get; set; }
        public bool IsSpecialOffer { get; set; }
        public bool Status { get; set; }
        public ICollection<WorkoutProgram>? Programs { get; set; }
        public ICollection<SubscriptionPayment>? SubscriptionPayments { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
