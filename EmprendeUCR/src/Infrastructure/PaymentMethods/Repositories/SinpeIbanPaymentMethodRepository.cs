using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using EmprendeUCR.Domain.PaymentMethods.Repositories;
using Microsoft.EntityFrameworkCore;
namespace EmprendeUCR.Infrastructure.PaymentMethods.Repositories
{
    internal class SinpeIbanPaymentMethodRepository : ISinpeIbanPaymentMethodRepository
    {
        private readonly PaymentMethodsDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        public SinpeIbanPaymentMethodRepository(PaymentMethodsDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }
        public async Task<IEnumerable<SinpeIbanPaymentMethod>> GetAllAsync()
        {
            return await _dbContext.SinpeIbanPaymentMethod
            .Select(p => new SinpeIbanPaymentMethod(p.Name, p.Status))
            .ToListAsync();
        }
        public async Task<SinpeIbanPaymentMethod?> GetByIdAsync(string name)
        {
            return await _dbContext.SinpeIbanPaymentMethod
            .FirstOrDefaultAsync(t => t.Name == name);
        }
        /// <summary>
        /// Saves aggregate and commits changes
        /// </summary>
        public async Task SaveAsync(SinpeIbanPaymentMethod paymentMethod)
        {
            _dbContext.Update(paymentMethod);
            await _dbContext.SaveEntitiesAsync();
        }
        public async Task DeletePaymentInformation(SinpeIbanPaymentInfo sinpeIbanPaymentInfo)
        {
            _dbContext.Remove(sinpeIbanPaymentInfo);
            await _dbContext.SaveEntitiesAsync();
        }
    }
}