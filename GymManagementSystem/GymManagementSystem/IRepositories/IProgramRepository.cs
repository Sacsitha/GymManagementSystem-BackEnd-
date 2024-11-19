using GymManagementSystem.Entities;

namespace GymManagementSystem.IRepositories
{
    public interface IProgramRepository
    {
        Task<WorkoutProgram> CreateProgram(WorkoutProgram workoutProgram);
        Task<ProgramImages> CreateImage(ProgramImages programImages);
        Task<WorkoutProgram> GetWorkoutProgram(Guid id);
        Task<Subscription> GetSubscription(Guid id);
        Task<ProgramPayment> GetProgramPayment(Guid ProgramId, Guid SubscriptionPaymentId);
        Task<ProgramPayment> GetProgramPayment(Guid Id);
        Task<List<WorkoutProgram>> GetAllWorkoutProgram();
        Task<WorkoutProgram> UpdateProgram(WorkoutProgram workoutProgram);
        Task<ProgramPayment> UpdateProgramPayment(ProgramPayment programPayment);
        Task<ProgramPayment> CreateProgramPayment(ProgramPayment programPayment);
    }
}
