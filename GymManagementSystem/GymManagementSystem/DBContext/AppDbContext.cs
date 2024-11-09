using GymManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberMessage> MemberMessages { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<SkippedPayment> SkippedPayments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Payment> Payments { get; set; }
        //public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<ProgramPayment> ProgramPayments { get; set; }
        public DbSet<SubscriptionPayment> SubscriptionPayments { get; set; }
        public DbSet<ProgramImages> ProgramImages { get; set; }
    }
}
