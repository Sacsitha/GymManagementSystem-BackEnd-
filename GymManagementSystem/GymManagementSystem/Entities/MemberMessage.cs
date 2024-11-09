using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Entities
{
    public class MemberMessage
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Message { get; set; }
        public Guid? MemberId { get; set; }
        public Member? member { get; set; }
    }
}
