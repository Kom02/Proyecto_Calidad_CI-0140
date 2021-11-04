using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using EmprendeUCR.Domain.PaymentMethods.Repositories;
using EmprendeUCR.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
namespace EmprendeUCR.Infrastructure.PaymentMethods.Repositories
{
    internal class CardPaymentMethodRepository : ICardPaymentMethodRepository
    {
        private readonly PaymentMethodsDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        public CardPaymentMethodRepository(PaymentMethodsDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }
        public async Task<IEnumerable<CardPaymentMethod>> GetAllAsync()
        {
            return await _dbContext.CardPaymentMethod
            .Select(p => new CardPaymentMethod(p.Name, p.Status))
            .ToListAsync();
        }
        public async Task<CardPaymentMethod?> GetByIdAsync(string name)
        {
            return await _dbContext.CardPaymentMethod
            .FirstOrDefaultAsync(t => t.Name == name);
        }
        /// <summary>
        /// Saves aggregate and commits changes
        /// </summary>
        public async Task SaveAsync(CardPaymentMethod paymentMethod)
        {
            _dbContext.Update(paymentMethod);
            await _dbContext.SaveEntitiesAsync();
        }
        public async Task DeletePaymentInformation(CardPaymentInfo cardPaymentInfo)
        {
            _dbContext.Remove(cardPaymentInfo);
            await _dbContext.SaveEntitiesAsync();
        }
    }
}