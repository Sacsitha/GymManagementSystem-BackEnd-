using GymManagementSystem.DBContext;
using GymManagementSystem.Entities;
using GymManagementSystem.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Repositories
{
    public class AdminRepository: IAdminRepository
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }

        //Member Management
        public User CreateUser(User user)
        {
            var data =  _context.Users.Add(user);
             _context.SaveChanges();
            return data.Entity;
        }
        public async Task<List<Member>> GetAllMembers()
        {
            var data = await _context.Members.Include(m => m.User).Where(i => i.MemberStatus == true).ToListAsync();
            return data;
        }
        public async Task<Member> GetMember(Guid id)
        {
            var data = await _context.Members.Include(m => m.User).Where(i=>i.MemberStatus==true).FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
            {
                throw new Exception("Member is not found");
            }
            return data;
        }
        //Member update and delete (soft delete)
        public async Task<Member> UpdateMember(Member member)
        {
            var data=_context.Members.Update(member);
            await _context.SaveChangesAsync();
            return data.Entity;
        }
        public void DeleteMember(Member member)
        {
            _context.Members.Remove(member);
            _context.SaveChanges();
        }

        //Enrollment
        public Enrollment CreateEnrollment(Enrollment enrollment)
        {
            var data = _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
            return data.Entity;
        }
        public async Task<List<Enrollment>> GetMemberEnrollments(Guid Id)
        {
            var data = await _context.Enrollments.Include(i => i.Program).Include(p => p.Member).Where(i=>i.MemberId==Id ).ToListAsync();
            return data;
        }
        public async Task<List<Enrollment>> GetAllProgramEnrollments(Guid Id)
        {
            var data = await _context.Enrollments.Include(i => i.Program).Include(p => p.Member).Where(i => i.ProgramId == Id).ToListAsync();
            return data;
        }
        public async Task<List<Enrollment>> GetAllEnrollment()
        {
            var data = await _context.Enrollments.Include(i => i.Program).Include(p => p.Member).ToListAsync();
            return data;
        }
        public async Task<Enrollment> UpdateEnrollment(Enrollment enrollment)
        {
            var data =_context.Enrollments.Update(enrollment);
            return data.Entity;
        }
        public void DeleteEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();
        }
        //Program
        public WorkoutProgram CreateProgram(WorkoutProgram workoutProgram)
        {
            var data = _context.WorkoutPrograms.Add(workoutProgram);
            _context.SaveChanges();
            return data.Entity;
        }
        public ProgramPayment CreateProgramPayment(ProgramPayment programPayment)
        {
            var data = _context.ProgramPayments.Add(programPayment);
            _context.SaveChanges();
            return data.Entity;
        }
        public ProgramImages CreateProgramImage(ProgramImages programImages)
        {
            var data = _context.ProgramImages.Add(programImages);
            _context.SaveChanges();
            return data.Entity;
        }
        public async Task<WorkoutProgram> GetWorkoutProgram(Guid id)
        {
            var data = await _context.WorkoutPrograms.Include(i=>i.ProgramPayments).Include(p=>p.Images).Where(i=>i.Status==true).FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
            {
                throw new Exception("Program not found");
            }
            return data;
        }
        public async Task<List<WorkoutProgram>> GetAllWorkoutProgram()
        {
            var data = await _context.WorkoutPrograms.Include(i => i.ProgramPayments).Where(i => i.Status == true).Include(p => p.Images).ToListAsync();
            return data;
        }
        //Program update and delete (soft delete)
        public async Task<WorkoutProgram> UpdateProgram(WorkoutProgram workoutProgram)
        {
            var data = _context.WorkoutPrograms.Update(workoutProgram);
            await _context.SaveChangesAsync();
            return data.Entity;
        }
        public void DeleteProgram(WorkoutProgram workoutProgram)
        {
            _context.WorkoutPrograms.Remove(workoutProgram);
            _context.SaveChanges();
        }

        //Subscription
        public Subscription CreateSubscription(Subscription subscription)
        {
            var data = _context.Subscriptions.Add(subscription);
            _context.SaveChanges();
            return data.Entity;
        }
        public SubscriptionPayment CreateSubscriptionPayment(SubscriptionPayment subscriptionPayment)
        {
            var data = _context.SubscriptionPayments.Add(subscriptionPayment);
            _context.SaveChanges();
            return data.Entity;
        }
        public async Task<Subscription> GetSubscription(Guid id)
        {
            var data = await _context.Subscriptions.Include(i => i.SubscriptionPayments).Where(i => i.Status == true).FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
            {
                throw new Exception("Program not found");
            }
            return data;
        }
        public async Task<List<Subscription>> GetAllSubscriptions()
        {
            var data = await _context.Subscriptions.Include(i => i.SubscriptionPayments).Where(i => i.Status == true).ToListAsync();
            return data;
        }
        //Program update and delete (soft delete)
        public async Task<Subscription> UpdateSubscription(Subscription subscription)
        {
            var data = _context.Subscriptions.Update(subscription);
            await _context.SaveChangesAsync();
            return data.Entity;
        }
        public void DeleteProgram(Subscription subscription)
        {
            _context.Subscriptions.Remove(subscription);
            _context.SaveChanges();
        }

    }
}
