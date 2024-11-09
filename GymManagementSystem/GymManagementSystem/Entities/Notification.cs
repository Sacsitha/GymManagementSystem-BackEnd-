namespace GymManagementSystem.Entities
{
    public class Notification
    {
        public Guid NId { get; set; }
        public string Message { get; set; } 
        public Priority Priority {  get; set; }
        public Guid MemberId { get; set; }
        public ICollection<User> Users { get; set; }
    }
    public enum Priority
    {
        Low,
        Medium,
        Heigh
    }
}
