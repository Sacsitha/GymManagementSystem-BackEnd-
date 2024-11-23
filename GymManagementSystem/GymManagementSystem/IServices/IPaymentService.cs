using GymManagementSystem.DTO.RequestDTO;
using GymManagementSystem.DTO.Response_DTO;

namespace GymManagementSystem.IServices
{
    public interface IPaymentService
    {
        Task<string> AddPayment(PaymentRequestDTO payment);
        Task<string> AddRefund(RefundRequestDTO refund);
        Task<string> AddSkippedPayment(SkippedPaymentRequestDTO skippedPayment);
        Task<List<PaymentResponseDTO>> GetAllPayments();
        Task<List<RefundResponseDTO>> GetAllRefunds();
        Task<List<SkippedPaymentResponseDTO>> GetAllSkippedPayment();
        Task<List<PaymentResponseDTO>> GetMemberPayments(Guid memberId);
        Task<List<RefundResponseDTO>> GetMemberRefunds(Guid id);
        Task<List<SkippedPaymentResponseDTO>> GetMemberSkippedPayment(Guid id);
        Task<List<MemberProgramResponseDTO>> GetOverDueMembers();
    }
}
