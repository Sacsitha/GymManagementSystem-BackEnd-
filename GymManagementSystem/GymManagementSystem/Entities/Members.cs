namespace GymManagementSystem.Entities
{
    public class Members
    {
        public Guid MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public  string Password { get; set; }
        public DateTime DOB {  get; set; }
        public string ContactNo { get; set; } 
        public string Email { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public DateTime CreationDate { get; set; }
        public bool MemberStatus { get; set; }
        public string Address { get; set; }
        public string NicNo { get; set; }
        public string UserId { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
