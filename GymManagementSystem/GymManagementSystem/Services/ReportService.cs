using GymManagementSystem.DTO.Response_DTO;
using GymManagementSystem.Entities;
using GymManagementSystem.IRepositories;
using GymManagementSystem.IServices;

namespace GymManagementSystem.Services
{
    public class ReportService : IReportService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProgramRepository _programRepository;
        private readonly IPaymentRepository _paymentRepository;

        public ReportService(IMemberRepository memberRepository, IProgramRepository programRepository,IPaymentRepository paymentRepository)
        {
            _memberRepository = memberRepository;
            _programRepository = programRepository;
            _paymentRepository = paymentRepository;
        }
        //Program Report
        //[{Program_Name:name,Enrollments:0(count)}]
        public async Task<List<ProgramReportResponse>> GetEnrollmentCount()
        {
            List<WorkoutProgram> Programs = _programRepository.GetAllWorkoutProgram() ;
            List<ProgramReportResponse> responseList = new List<ProgramReportResponse>();
            if(Programs == null) { throw new Exception("Programs not available"); };
            foreach (WorkoutProgram program in Programs)
            {
                List<Enrollment> enrollments = _memberRepository.GetAllProgramEnrollments(program.Id);
                int enrollmentCount=enrollments.Count();
                ProgramReportResponse response = new ProgramReportResponse()
                {
                    ProgramName = program.Name,
                    Enrollments = enrollmentCount
                };
                responseList.Add(response);
            }
            return responseList;
        }
        //Annual Payment Report

        public async Task<List<IncomeResponseDTO>> AnnualFinancialIncome(int? year)
        {
            List<IncomeResponseDTO> responseList = new List<IncomeResponseDTO>();
            var annualPayments = await _paymentRepository.GetPaymentsByYear(year ?? DateTime.Now.Year);
            var refunds= await _paymentRepository.GetYearRefundPayments(year ?? DateTime.Now.Year);
            if (annualPayments == null && refunds ==null) { throw new Exception("No data found"); };
            for (int i = 1; i <= 12; i++)
            {
                decimal totalPayments = 0;
                decimal totalRefunds = 0;
                foreach (var payment in annualPayments)
                {
                    if (payment.PaymentDate.Month == i)
                    {
                        totalPayments += payment.ProgramPayment.Amount;
                    }
                }
                foreach (var payment in refunds)
                {
                    if (payment.Date.Month == i)
                    {
                        totalRefunds += payment.Amount;
                    }
                }
                IncomeResponseDTO response = new IncomeResponseDTO()
                {
                    Month = new DateTime(year ?? DateTime.Now.Year, i, 1).ToString("MMMM"),
                    Income = totalPayments - totalRefunds
                };
                Console.WriteLine(response);
                responseList.Add(response);
            }
            return responseList;
        }

        //Member Report
        //[{Age :'15-24',Male : 20 ,Female :30 }]
        public async Task<List<MemberReportResponse>> MemberReport()
        {
            List<MemberReportResponse> responseList = new List<MemberReportResponse>();
            var memberList = _memberRepository.GetAllMembers();
            if(memberList == null)
            {
                throw new Exception("No data found");
            }
            for (int i=15; i<=100; i=i+10)
            {
                int Males = 0;
                int Females = 0;
                foreach (var member in memberList)
                {
                    if(member.Age>= i && member.Age<= i + 9)
                    {
                    if (member.Gender == "Male")
                    {
                        Males += 1;
                    }
                    else
                    {
                        Females += 1;
                    }
                    }
                }
                MemberReportResponse response = new MemberReportResponse()
                {
                    Age = i+"-"+(i+9),
                    Males = Males,
                    Females = Females
                };
                responseList.Add(response);
            }
            return responseList;
        }
        //Monthly Financial Report
        //[{PaymentType : "Annual fee ",Amount : 1000} ]
        public async Task<List<MonthlyIncomeResponse>> MonthlyFinancialReport(int? month)
        {
            List<MonthlyIncomeResponse> responseList = new List<MonthlyIncomeResponse>();
            var monthlyPayments = await _paymentRepository.GetPaymentsByMonth(month ?? DateTime.Now.Month);
            var paymentTypes =  _programRepository.GetSubscriptionAllPayment();
            foreach (var paymentType in paymentTypes)
            {
                decimal total = 0;
                foreach (var payment in monthlyPayments)
                {
                    if(payment.ProgramPayment.SubscriptionPaymentId == paymentType.Id)
                    {
                        total += payment.ProgramPayment.Amount;
                    }
                }
                MonthlyIncomeResponse response = new MonthlyIncomeResponse()
                {
                    PaymentType = paymentType.PaymentType,
                    Amount = total
                };
                responseList.Add(response);
            }
            return responseList;
        }

    }
}
