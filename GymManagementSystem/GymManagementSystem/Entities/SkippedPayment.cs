using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Entities
{
    public class SkippedPayment
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }
        public string Reason { get; set; }
        public Guid MemberId { get; set; }
        public Member Member { get; set; }
        public Guid ProgramId { get; set; }
        public WorkoutProgram Program { get; set; }
    }
}
