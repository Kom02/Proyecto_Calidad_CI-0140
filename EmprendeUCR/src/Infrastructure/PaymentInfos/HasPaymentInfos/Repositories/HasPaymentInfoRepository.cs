using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentInfos.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmprendeUCR.Infrastructure.PaymentInfos.HasPaymentInfos.Repositories
{
    internal class HasPaymentInfoRepository : IHasPaymentInfoRepository
    {
        private readonly HasPaymentInfoDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        public HasPaymentInfoRepository(HasPaymentInfoDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }
        public async Task SaveAsync(HasPaymentInfo hasPaymentInfo)
        {
            _dbContext.Update(hasPaymentInfo);
            await _dbContext.SaveEntitiesAsync();
        }
        public async Task AddHasPaymentInfo(HasPaymentInfo hasPaymentInfo)
        {
            await _dbContext.AddAsync(hasPaymentInfo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<HasPaymentInfo>> GetAllAsync()
        {
            return await _dbContext.HasPaymentInfo
            .Select(p => new HasPaymentInfo(p.Entrepreneur_Email,p.Payment_Info_ID))
            .ToListAsync();
        }
    }
}