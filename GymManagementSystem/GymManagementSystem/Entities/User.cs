namespace GymManagementSystem.Entities
{
    public class User
    {
        public string UserId { get; set; }
        public string PassWord { get; set; }
        public Roles Roles { get; set; }
    }

    public enum Roles
    {
        Admin,
        member
    }
}
