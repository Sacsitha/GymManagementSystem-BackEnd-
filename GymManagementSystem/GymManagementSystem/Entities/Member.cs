﻿using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Entities
{
    public class Member
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool MemberStatus { get; set; }
        public string Address { get; set; }
        public string NicNo { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
        public ICollection<Payment>? Payments { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<SkippedPayment>? SkippedPayments { get; set; }
        public ICollection<MemberMessage>? MemberMessages { get; set; }
        //public ICollection<Enrollment>? Enrollments { get; set; }

    }
}
