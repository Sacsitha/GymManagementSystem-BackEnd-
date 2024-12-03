using GymManagementSystem.IRepositories;
using GymManagementSystem.IServices;

namespace GymManagementSystem.Services
{
    public class ReportService : IReportService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProgramRepository _programRepository;
        private readonly IPaymentService _paymentService;

        public ReportService(IMemberRepository memberRepository, IProgramRepository programRepository, IPaymentService paymentService)
        {
            _memberRepository = memberRepository;
            _programRepository = programRepository;
            _paymentService = paymentService;
        }

       
    }
}
