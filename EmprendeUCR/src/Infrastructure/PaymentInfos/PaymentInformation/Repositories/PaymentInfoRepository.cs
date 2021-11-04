using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentInfos.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmprendeUCR.Infrastructure.PaymentInfos.PaymentInformation.Repositories
{
    internal class PaymentInfoRepository : IPaymentInfoRepository
    {
        private readonly PaymentInfoDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        public PaymentInfoRepository(PaymentInfoDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }
        public async Task<IEnumerable<PaymentInfo>> GetAllAsync()
        {
            return await _dbContext.PaymentInfo
            .Select(p => new PaymentInfo(p.ID))
            .ToListAsync();
        }
        public async Task<PaymentInfo?> GetByIdAsync(int id)
        {
            return await _dbContext.PaymentInfo
            .FirstOrDefaultAsync(p => p.ID == id);
        }
        /// <summary>
        /// Saves aggregate and commits changes
        /// </summary>
        public async Task SaveAsync(PaymentInfo paymentInfo)
        {
            _dbContext.Update(paymentInfo);
            await _dbContext.SaveEntitiesAsync();
        }
        public async Task<PaymentInfo?> AddPaymentInfo()
        {
            PaymentInfo paymentInfo = new PaymentInfo();
            await _dbContext.AddAsync(paymentInfo);
            await _dbContext.SaveChangesAsync();
            return paymentInfo;
        }
        public async Task RemovePaymentInfo(int id) {
            PaymentInfo paymentInfo = await GetByIdAsync(id);
            _dbContext.Remove(paymentInfo);
            await _dbContext.SaveChangesAsync();
        }
    }
}