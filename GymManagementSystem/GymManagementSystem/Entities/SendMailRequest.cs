namespace GymManagementSystem.Entities
{
    public class SendMailRequest
    {
        public string? Name { get; set; }
        public string? Otp { get; set; }
        public User? User { get; set; } 
        public string? Email { get; set; }
        public Email EmailType { get; set; }
    }
}
