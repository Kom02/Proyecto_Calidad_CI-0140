using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentInfos.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmprendeUCR.Infrastructure.PaymentInfos.SinpeMovil.Repositories
{
    internal class SinpeMovilPaymentInfoRepository : ISinpeMovilPaymentInfoRepository
    {
        private readonly SinpeMovilPaymentInfoDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        public SinpeMovilPaymentInfoRepository(SinpeMovilPaymentInfoDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }
        public async Task<IEnumerable<SinpeMovilPaymentInfo>> GetAllAsync()
        {
            return await _dbContext.SinpeMovilPaymentInfo
            .Select(p => new SinpeMovilPaymentInfo(p.Phone_Number, p.Payment_Info_ID, p.Name_Payment_Method))
            .ToListAsync();
        }
        public async Task<SinpeMovilPaymentInfo?> GetByIdAsync(int phoneNumber)
        {
            return await _dbContext.SinpeMovilPaymentInfo
            .FirstOrDefaultAsync(p => p.Phone_Number == phoneNumber);
        }
        /// <summary>
        /// Saves aggregate and commits changes
        /// </summary>
        public async Task SaveAsync(SinpeMovilPaymentInfo sinpeMovilPaymentInfo)
        {
            _dbContext.Update(sinpeMovilPaymentInfo);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task AddPaymentInfo(SinpeMovilPaymentInfo sinpeMovilPaymentInfo)
        {
            await _dbContext.AddAsync(sinpeMovilPaymentInfo);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<SinpeMovilPaymentInfo?> GetByPaymentInfoID(int id)
        {
            return await _dbContext.SinpeMovilPaymentInfo
            .FirstOrDefaultAsync(p => p.Payment_Info_ID.Equals(id));
        }
    }
}