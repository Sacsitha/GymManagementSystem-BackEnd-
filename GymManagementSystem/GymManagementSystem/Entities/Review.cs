using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Entities
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string ReviewMessage { get; set; }
        public Guid? MemberId { get; set; }
        public Member? member { get; set; }

    }
}
