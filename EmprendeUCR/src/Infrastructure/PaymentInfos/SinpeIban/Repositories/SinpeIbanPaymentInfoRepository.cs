using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentInfos.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmprendeUCR.Infrastructure.PaymentInfos.SinpeIban.Repositories
{
    internal class SinpeIbanPaymentInfoRepository : ISinpeIbanPaymentInfoRepository
    {
        private readonly SinpeIbanPaymentInfoDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        public SinpeIbanPaymentInfoRepository(SinpeIbanPaymentInfoDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }
        public async Task<IEnumerable<SinpeIbanPaymentInfo>> GetAllAsync()
        {
            return await _dbContext.SinpeIbanPaymentInfo
            .Select(p => new SinpeIbanPaymentInfo(p.Account_Number, p.Payment_Info_ID, p.Name_Payment_Method))
            .ToListAsync();
        }
        public async Task<SinpeIbanPaymentInfo?> GetByIdAsync(string accountNumber)
        {
            bool validationForInjections = false;
            if (accountNumber.Contains("1=1"))
            {
                validationForInjections = true;
            }
            else if (accountNumber.Contains("'"))
            {
                validationForInjections = true;
            }
            else if (accountNumber.Contains("--"))   // because if u use -- it can comment the next part of the query
            {
                validationForInjections = true;
            }
            if (!validationForInjections)
            {
                return await _dbContext.SinpeIbanPaymentInfo.FirstOrDefaultAsync(p => p.Account_Number == accountNumber);
            }
            return await _dbContext.SinpeIbanPaymentInfo.FindAsync("No existe");
        }
            /// <summary>
        /// Saves aggregate and commits changes
        /// </summary>
        public async Task SaveAsync(SinpeIbanPaymentInfo sinpeIbanPaymentInfo)
        {

            _dbContext.Update(sinpeIbanPaymentInfo);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task AddPaymentInfo(SinpeIbanPaymentInfo sinpeIbanPaymentInfo)
        {
            bool validationForInjections = false;
            validationForInjections = sinpeIbanPaymentInfo.Account_Number.Contains("1=1");
            if (!validationForInjections)
            {
                await _dbContext.AddAsync(sinpeIbanPaymentInfo);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Numero de cuenta invalido");
            }
        }
        public async Task<SinpeIbanPaymentInfo?> GetByPaymentInfoID(int id)
        {
            return await _dbContext.SinpeIbanPaymentInfo
            .FirstOrDefaultAsync(p => p.Payment_Info_ID.Equals(id));
        }
    }
}