using GymManagementSystem.Entities;

namespace GymManagementSystem.IRepositories
{
    public interface IPaymentRepository
    {
        Payment AddPayment(Payment payment);
        RefundPayment AddRefundPayment(RefundPayment refundPayment);
        SkippedPayment AddSkippedPayment(SkippedPayment skippedPayment);
        void DeletePayment(Payment member);
        void DeleteRefundPayment(RefundPayment refundPayment);
        void DeleteSkippedPayment(SkippedPayment skippedPayment);
        Task<List<Payment>> GetAllPayments();
        List<RefundPayment> GetAllRefundPayments();
        List<SkippedPayment> GetAllSkippedPayments();
        Task<List<Payment>> GetMemberPayments(Guid id);
        List<RefundPayment> GetMemberRefundPayment(Guid id);
        List<SkippedPayment> GetMemberSkippedPayments(Guid id);
        Task<List<Payment>> GetPaymentsByMonth(int month);
        Task<List<Payment>> GetPaymentsByYear(int year);
        RefundPayment GetRefundPayment(Guid id);
        Payment GetSinglePayment(Guid id);
        SkippedPayment GetSkippedPayment(Guid id);
        Task<List<RefundPayment>> GetYearRefundPayments(int year);
        Payment UpdatePayment(Payment member);
        RefundPayment UpdateRefundPayment(RefundPayment refundPayment);
        SkippedPayment UpdateSkippedPayment(SkippedPayment skippedPayment);
    }
}
