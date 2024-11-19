using GymManagementSystem.DBContext;
using GymManagementSystem.Entities;
using GymManagementSystem.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Repositories
{
    public class MemberRepository: IMemberRepository
    {
        private readonly AppDbContext _context;

        public MemberRepository(AppDbContext context)
        {
            _context = context;
        }
        public User CreateUser(User user)
        {
            var data = _context.Users.Add(user);
            _context.SaveChanges();
            return data.Entity;
        }
        //public async Task<List<Member>> GetAllMembers()
        //{
        //    var data = await _context.Members.Include(m => m.User).Where(i => i.MemberStatus == true).ToListAsync();
        //    return data;
        //}
        public async Task<List<Member>> GetAllMembers()
        {
            var data = await _context.Members
                .Include(m => m.User) // Including the User details for the member
                .Where(i => i.MemberStatus == true) // Filter active members
                .ToListAsync();

            return data;
        }
        public async Task<Member> GetMember(Guid id)
        {
            var data = await _context.Members.Include(m => m.User).Where(i => i.MemberStatus == true).FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
            {
                throw new Exception("Member is not found");
            }
            return data;
        }
        //Member update and delete (soft delete)
        public async Task<Member> UpdateMember(Member member)
        {
            var data = _context.Members.Update(member);
            await _context.SaveChangesAsync();
            return data.Entity;
        }
        public void DeleteMember(Member member)
        {
            _context.Members.Remove(member);
            _context.SaveChanges();
        }

        //Enrollment
        public async Task<Enrollment> CreateEnrollment(Enrollment enrollment)
        {
            var data = _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
            return data.Entity;
        }
        public async Task<Enrollment> GetEnrollments(Guid memberId,Guid programId)
        {
            var data = await _context.Enrollments.Where(i => i.MemberId == memberId).FirstOrDefaultAsync(j=>j.ProgramId==programId);
            return data;
        }
        public async Task<List<Enrollment>> GetMemberEnrollments(Guid Id)
        {
            var data = await _context.Enrollments.Include(i => i.Program).Include(p => p.Member).Where(i => i.MemberId == Id).ToListAsync();
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
            var data = _context.Enrollments.Update(enrollment);
            return data.Entity;
        }
        public async Task<List<WorkoutProgram>> NotEnrolledPrograms(List<Guid>? excludeProgramIds)
        {
            if (excludeProgramIds == null || !excludeProgramIds.Any())
            {
                return await _context.WorkoutPrograms.ToListAsync();
            }

            var data = await _context.WorkoutPrograms
                .Where(p => !excludeProgramIds.Contains(p.Id))
                .ToListAsync();

            return data;
        }
        public void DeleteEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();
        }
    }
}
