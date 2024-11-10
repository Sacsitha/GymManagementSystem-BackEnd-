using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Entities
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string PassWord { get; set; }
        public Roles Roles { get; set; }
        public Member? Member { get; set; }
    }

    public enum Roles
    {
        Admin,
        Member
    }
}
