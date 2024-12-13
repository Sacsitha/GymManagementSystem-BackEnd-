using GymManagementSystem.DTO.Response_DTO;
using GymManagementSystem.Entities;

namespace GymManagementSystem.IServices
{
    public interface IReportService
    {
        Task<List<IncomeResponseDTO>> AnnualFinancialIncome(int? year);
        //Task<string> AnnualFinancialIncome(int? year);

        //Task<List<Payment>> AnnualFinancialIncome(int? year);
        Task<List<ProgramReportResponse>> GetEnrollmentCount();
        Task<List<MemberReportResponse>> MemberReport();
        Task<List<MonthlyIncomeResponse>> MonthlyFinancialReport(int? month);
    }
}
