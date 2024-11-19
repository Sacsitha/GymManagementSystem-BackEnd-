using GymManagementSystem.DBContext;
using GymManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Repositories
{
    public class PaymentsRepository
    {
        private readonly AppDbContext _context;

        public PaymentsRepository(AppDbContext context)
        {
            _context = context;
        }

        //Payment Management
        public Payment CreateUser(Payment payment)
        {
            var data = _context.Payments.Add(payment);
            _context.SaveChanges();
            return data.Entity;
        }
        public async Task<List<Payment>> GetAllPayments()
        {
            var data = await _context.Payments.Include(m => m.Member).ToListAsync();
            return data;
        }
        public async Task<List<Payment>> GetAllRefundPaymentPayments(Guid id)
        {
            var data = await _context.Payments.Include(m => m.Member).Where(i=>i.MemberId == id).ToListAsync();
            return data;
        }
        public async Task<Payment> GetPayment(Guid id)
        {
            var data = await _context.Payments.Include(m => m.Member).FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
            {
                throw new Exception("Payment is not found");
            }
            return data;
        }
        public async Task<Payment> UpdatePayment(Payment member)
        {
            var data = _context.Payments.Update(member);
            await _context.SaveChangesAsync();
            return data.Entity;
        }
        public void DeletePayment(Payment member)
        {
            _context.Payments.Remove(member);
            _context.SaveChanges();
        }


        //Refund Payment

        public RefundPayment CreateUser(RefundPayment refundPayment)
        {
            var data = _context.RefundPayments.Add(refundPayment);
            _context.SaveChanges();
            return data.Entity;
        }
        public async Task<List<RefundPayment>> GetAllRefundPayments()
        {
            var data = await _context.RefundPayments.Include(m => m.Member).ToListAsync();
            return data;
        }
        public async Task<RefundPayment> GetRefundPayment(Guid id)
        {
            var data = await _context.RefundPayments.Include(m => m.Member).FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
            {
                throw new Exception("RefundPayment is not found");
            }
            return data;
        }
        public async Task<RefundPayment> UpdateRefundPayment(RefundPayment refundPayment)
        {
            var data = _context.RefundPayments.Update(refundPayment);
            await _context.SaveChangesAsync();
            return data.Entity;
        }
        public void DeleteRefundPayment(RefundPayment refundPayment)
        {
            _context.RefundPayments.Remove(refundPayment);
            _context.SaveChanges();
        }

        //SkippedPayment
        public SkippedPayment CreateUser(SkippedPayment skippedPayment)
        {
            var data = _context.SkippedPayments.Add(skippedPayment);
            _context.SaveChanges();
            return data.Entity;
        }
        public async Task<List<SkippedPayment>> GetAllSkippedPayments()
        {
            var data = await _context.SkippedPayments.Include(m => m.Member).ToListAsync();
            return data;
        }
        public async Task<SkippedPayment> GetSkippedPayment(Guid id)
        {
            var data = await _context.SkippedPayments.Include(m => m.Member).FirstOrDefaultAsync(i => i.Id == id);
            if (data == null)
            {
                throw new Exception("SkippedPayment is not found");
            }
            return data;
        }
        public async Task<SkippedPayment> UpdateSkippedPayment(SkippedPayment skippedPayment)
        {
            var data = _context.SkippedPayments.Update(skippedPayment);
            await _context.SaveChangesAsync();
            return data.Entity;
        }
        public void DeleteSkippedPayment(SkippedPayment skippedPayment)
        {
            _context.SkippedPayments.Remove(skippedPayment);
            _context.SaveChanges();
        }
    }
}
