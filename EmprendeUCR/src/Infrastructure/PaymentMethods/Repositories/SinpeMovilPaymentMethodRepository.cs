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
    internal class SinpeMovilPaymentMethodRepository : ISinpeMovilPaymentMethodRepository
    {
        private readonly PaymentMethodsDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        public SinpeMovilPaymentMethodRepository(PaymentMethodsDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }
        public async Task<IEnumerable<SinpeMovilPaymentMethod>> GetAllAsync()
        {
            return await _dbContext.SinpeMovilPaymentMethod
            .Select(p => new SinpeMovilPaymentMethod(p.Name, p.Status))
            .ToListAsync();
        }
        public async Task<SinpeMovilPaymentMethod?> GetByIdAsync(string name)
        {
            return await _dbContext.SinpeMovilPaymentMethod
            .FirstOrDefaultAsync(t => t.Name == name);
        }
        /// <summary>
        /// Saves aggregate and commits changes
        /// </summary>
        public async Task SaveAsync(SinpeMovilPaymentMethod paymentMethod)
        {
            _dbContext.Update(paymentMethod);
            await _dbContext.SaveEntitiesAsync();
        }
        public async Task DeletePaymentInformation(SinpeMovilPaymentInfo sinpeMovilPaymentInfo)
        {
            _dbContext.Remove(sinpeMovilPaymentInfo);
            await _dbContext.SaveEntitiesAsync();
        }
    }
}