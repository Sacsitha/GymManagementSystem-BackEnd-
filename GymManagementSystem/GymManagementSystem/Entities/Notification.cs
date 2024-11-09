using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Entities
{
    public class Notification
    {
        [Key]
        public Guid Id { get; set; }
        public string Message { get; set; } 
        public Priority Priority {  get; set; }
        public Guid? MemberId { get; set; }
        public Member? member { get; set; }
    }
    public enum Priority
    {
        Low,
        Medium,
        Heigh
    }
}
