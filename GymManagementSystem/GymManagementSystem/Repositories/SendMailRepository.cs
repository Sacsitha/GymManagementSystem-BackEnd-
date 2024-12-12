using GymManagementSystem.DBContext;
using GymManagementSystem.Entities;

namespace GymManagementSystem.Repositories
{
    public class SendMailRepository(AppDbContext _Context)
    {
        public async Task<EmailTemplate> GetTemplate(Email emailTypes)
        {
            var template = _Context.EmailTemplates.Where(x => x.emailTypes == emailTypes).FirstOrDefault();
            return template;
        }

    }
}
