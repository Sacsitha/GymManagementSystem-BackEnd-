using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Entities
{
    public class Enrollment
    {
        [Key]
        public Guid MemberId { get; set; }
        public Member? member { get; set; }
        [Key]
        public Guid ProgramId {  get; set; }
        public Program? program { get; set; }
        [Required]
        public DateTime EnrolledDate { get; set; }
        [Required]
        public DateTime NextDueDate { get; set; }
        public Guid? SubscriptionId { get; set; }
        public Subscription? Subscription { get; set; }
    }
}
