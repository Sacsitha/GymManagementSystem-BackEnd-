using GymManagementSystem.Entities;

namespace GymManagementSystem.IRepositories
{
    public interface IMemberRepository
    {
        User CreateUser(User user);
        Task<List<Member>> GetAllMembers();
        Task<Member> GetMember(Guid id);
        Task<Member> UpdateMember(Member member);
        Task<List<Enrollment>> GetMemberEnrollments(Guid Id);
        Task<Enrollment> CreateEnrollment(Enrollment enrollment);
        Task<Enrollment> GetEnrollments(Guid memberId, Guid programId);
        void DeleteEnrollment(Enrollment enrollment);
        Task<List<WorkoutProgram>> NotEnrolledPrograms(List<Guid>? excludeProgramIds);
    }
}
