using GymManagementSystem.DBContext;
using GymManagementSystem.Entities;
using GymManagementSystem.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Repositories
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }
        public Payment AddPayment(Payment payment)
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
        public async Task<List<Payment>> GetMemberPayments(Guid id)
        {
            var data = await _context.Payments.Include(m => m.Member).Where(i => i.MemberId == id).ToListAsync();
            return data;
        }
        public Payment GetSinglePayment(Guid id)
        {
            var data =  _context.Payments.Include(m => m.Member).FirstOrDefault(i => i.Id == id);
            if (data == null)
            {
                throw new Exception("Payment is not found");
            }
            return data;
        }
        public Payment UpdatePayment(Payment member)    
        {
            var data = _context.Payments.Update(member);
            _context.SaveChanges();
            return data.Entity;
        }
        public void DeletePayment(Payment member)
        {
            _context.Payments.Remove(member);
            _context.SaveChanges();
        }


        //Refund Payment

        public RefundPayment AddRefundPayment(RefundPayment refundPayment)
        {
            var data = _context.RefundPayments.Add(refundPayment);
            _context.SaveChanges();
            return data.Entity;
        }
        public List<RefundPayment> GetAllRefundPayments()
        {
            var data =  _context.RefundPayments.Include(m => m.Member).ToList();
            return data;
        }
        public RefundPayment GetRefundPayment(Guid id)
        {
            var data =  _context.RefundPayments.Include(m => m.Member).FirstOrDefault(i => i.Id == id);
            if (data == null)
            {
                throw new Exception("RefundPayment is not found");
            }
            return data;
        }
        public List<RefundPayment> GetMemberRefundPayment(Guid id)
        {
            var data =  _context.RefundPayments.Include(m => m.Member).Where(i => i.MemberId == id).ToList();
            if (data == null)
            {
                throw new Exception("Member not found");
            }
            return data;
        }
        public RefundPayment UpdateRefundPayment(RefundPayment refundPayment)
        {
            var data = _context.RefundPayments.Update(refundPayment);
            _context.SaveChanges();
            return data.Entity;
        }
        public void DeleteRefundPayment(RefundPayment refundPayment)
        {
            _context.RefundPayments.Remove(refundPayment);
            _context.SaveChanges();
        }

        //SkippedPayment
        public SkippedPayment AddSkippedPayment(SkippedPayment skippedPayment)
        {
            var data = _context.SkippedPayments.Add(skippedPayment);
            _context.SaveChanges();
            return data.Entity;
        }
        public List<SkippedPayment> GetAllSkippedPayments()
        {
            var data =  _context.SkippedPayments.Include(m => m.Member).Include(i=>i.Program).ToList();
            return data;
        }
        public List<SkippedPayment> GetMemberSkippedPayments(Guid id)
        {
            var data = _context.SkippedPayments.Include(m => m.Member).Include(i => i.Program).Where(j=>j.MemberId==id).ToList();
            return data;
        }
        public SkippedPayment GetSkippedPayment(Guid id)
        {
            var data =  _context.SkippedPayments.Include(m => m.Member).FirstOrDefault(i => i.Id == id);
            if (data == null)
            {
                throw new Exception("SkippedPayment is not found");
            }
            return data;
        }
        public SkippedPayment UpdateSkippedPayment(SkippedPayment skippedPayment)
        {
            var data = _context.SkippedPayments.Update(skippedPayment);
            _context.SaveChanges();
            return data.Entity;
        }
        public void DeleteSkippedPayment(SkippedPayment skippedPayment)
        {
            _context.SkippedPayments.Remove(skippedPayment);
            _context.SaveChanges();
        }
    }
}
