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
        public ICollection<WorkoutProgram> Programs { get; set; }
        public ICollection<SubscriptionPayment> SubscriptionPayments { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
