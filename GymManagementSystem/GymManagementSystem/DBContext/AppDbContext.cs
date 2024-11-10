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
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<WorkoutProgram> WorkoutPrograms { get; set; }
        public DbSet<ProgramPayment> ProgramPayments { get; set; }
        public DbSet<SubscriptionPayment> SubscriptionPayments { get; set; }
        public DbSet<ProgramImages> ProgramImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Member
            modelBuilder.Entity<Member>().HasOne(a => a.User).WithOne(u => u.Member).HasForeignKey<Member>(u => u.UserId).OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Member>().HasMany(a => a.SkippedPayments).WithOne(u => u.member).HasForeignKey(u => u.MemberId);
            //modelBuilder.Entity<Member>().HasMany(a => a.Notifications).WithOne(u => u.member).HasForeignKey(u => u.MemberId);
            //modelBuilder.Entity<Member>().HasMany(a => a.Payments).WithOne(u => u.member).HasForeignKey(u => u.MemberId);
            //modelBuilder.Entity<Member>().HasMany(a => a.MemberMessages).WithOne(u => u.member).HasForeignKey(u => u.MemberId);
            //modelBuilder.Entity<Member>().HasMany(a => a.Reviews).WithOne(u => u.member).HasForeignKey(u => u.MemberId);
            //modelBuilder.Entity<Member>().HasMany(a => a.Enrollments).WithOne(u => u.member).HasForeignKey(u => u.MemberId);

            //Workout Program
            //modelBuilder.Entity<WorkoutProgram>().HasMany(a => a.Images).WithOne(u => u.program).HasForeignKey(u => u.ProgramId);
            //modelBuilder.Entity<WorkoutProgram>().HasMany(a => a.ProgramPayments).WithOne(u => u.program).HasForeignKey(u => u.ProgramId);
            //modelBuilder.Entity<WorkoutProgram>().HasMany(a => a.Subscriptions).WithOne(u => u.Programs).HasForeignKey(u => u.ProgramId);
            //modelBuilder.Entity<WorkoutProgram>().HasMany(a => a.Enrollments).WithOne(u => u.program).HasForeignKey(u => u.ProgramId);

            //Subscription
            //modelBuilder.Entity<Subscription>().HasMany(a => a.SubscriptionPayments).WithOne(u => u.subscription).HasForeignKey(u => u.SubscriptionId);
            //modelBuilder.Entity<Subscription>().HasMany(a => a.Enrollments).WithOne(u => u.Subscription).HasForeignKey(u => u.SubscriptionId);
            //modelBuilder.Entity<Subscription>().HasMany(a => a.SubscriptionPayments).WithOne(u => u.Programs).HasForeignKey(u => u.SubscriptionId);

            modelBuilder.Entity<Enrollment>().HasKey(e => new { e.MemberId, e.ProgramId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
