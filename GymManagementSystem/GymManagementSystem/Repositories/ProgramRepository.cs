using GymManagementSystem.DBContext;
using GymManagementSystem.Entities;
using GymManagementSystem.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Repositories
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly AppDbContext _context;

        public ProgramRepository(AppDbContext context)
        {
            _context = context;
        }
        //Program
        public async Task<WorkoutProgram> CreateProgram(WorkoutProgram workoutProgram)
        {
            var data = _context.WorkoutPrograms.Add(workoutProgram);
            _context.SaveChanges();
            return data.Entity;
        }
        public async Task<ProgramImages> CreateImage(ProgramImages programImages)
        {
            var data = _context.ProgramImages.Add(programImages);
            _context.SaveChanges();
            return data.Entity;
        }
        public async Task<ProgramPayment> CreateProgramPayment(ProgramPayment programPayment)
        {
            var data = _context.ProgramPayments.Add(programPayment);
            _context.SaveChanges();
            return data.Entity;
        }

        public async Task<WorkoutProgram> GetWorkoutProgram(Guid id)
        {
            var data = await _context.WorkoutPrograms.Include(i => i.ProgramPayments.Where(p => p.Status == true)).Include(p => p.Images).Where(i => i.Status == true).FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
            {
                throw new Exception("Program not found");
            }
            return data;
        }
        public async Task<List<WorkoutProgram>> GetAllWorkoutProgram()
        {
            var data = await _context.WorkoutPrograms.Include(i => i.ProgramPayments.Where(p=>p.Status==true)).Where(i => i.Status == true).Include(p => p.Images).ToListAsync();
            return data;
        }
        //Program update and delete (soft delete)
        public async Task<WorkoutProgram> UpdateProgram(WorkoutProgram workoutProgram)
        {
            var data = _context.WorkoutPrograms.Update(workoutProgram);
            await _context.SaveChangesAsync();
            return data.Entity;
        }
        public async Task<ProgramPayment> UpdateProgramPayment(ProgramPayment programPayment)
        {
            var data = _context.ProgramPayments.Update(programPayment);
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
        public async Task<ProgramPayment> GetProgramPayment(Guid ProgramId,Guid SubscriptionPaymentId)
        {
            var data = await _context.ProgramPayments.Where(i=>i.ProgramId==ProgramId).Where(p=>p.Status==true).FirstOrDefaultAsync(s => s.SubscriptionPaymentId == SubscriptionPaymentId);
            return data;
        }
        public async Task<ProgramPayment> GetProgramPayment(Guid Id)
        {
            var data = await _context.ProgramPayments.FirstOrDefaultAsync(s => s.Id==Id);
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
