using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Entities
{
    public class AdminMessage
    {
        public Guid Id { get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
        public bool Status { get; set; }
        public Guid MemberId { get; set; }
        public Member Member { get; set; }
    }
}
