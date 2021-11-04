using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentInfos.Repositories;
using EmprendeUCR.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;

namespace EmprendeUCR.Infrastructure.PaymentInfos.Card.Repositories
{
    internal class CardPaymentInfoRepository : ICardPaymentInfoRepository
    {
        private readonly CardPaymentInfoDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        public CardPaymentInfoRepository(CardPaymentInfoDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }
        public async Task<IEnumerable<CardPaymentInfo>> GetAllAsync()
        {
            return await _dbContext.CardPaymentInfo
            .Select(p => new CardPaymentInfo(p.Account_Number, p.Payment_Info_ID, p.Name_Payment_Method))
            .ToListAsync();
        }
        public async Task<CardPaymentInfo?> GetByIdAsync(string accountNumber)
        {
            return await _dbContext.CardPaymentInfo
            .FirstOrDefaultAsync(p => p.Account_Number == accountNumber);
        }
        /// <summary>
        /// Saves aggregate and commits changes
        /// </summary>
        public async Task SaveAsync(CardPaymentInfo sinpeIbanPaymentInfo)
        {
            _dbContext.Update(sinpeIbanPaymentInfo);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task AddPaymentInfo(CardPaymentInfo sinpeIbanPaymentInfo)
        {
            await _dbContext.AddAsync(sinpeIbanPaymentInfo);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<CardPaymentInfo?> GetByPaymentInfoID(int id)
        {
            return await _dbContext.CardPaymentInfo
            .FirstOrDefaultAsync(p => p.Payment_Info_ID.Equals(id));
        }

    }
}