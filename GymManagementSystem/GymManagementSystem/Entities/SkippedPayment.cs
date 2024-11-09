using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Entities
{
    public class SkippedPayment
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }
        public string Reason { get; set; }
        public Guid? MemberId { get; set; }
        public Member? member { get; set; }
        public Guid ProgramId { get; set; }
        public Program? program { get; set; }
    }
}
