using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentInfos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Application.PaymentInfos.Implementations
{
    internal class HasPaymentInfoService : IHasPaymentInfoService
    {
        private readonly IHasPaymentInfoRepository _hasPaymentInfoRepository;
        public HasPaymentInfoService(IHasPaymentInfoRepository hasPaymentInfoRepository)
        {
           _hasPaymentInfoRepository = hasPaymentInfoRepository;
        }
        public async Task<List<HasPaymentInfo>?> getHasPaymentInfoByEmail(string entrepreneurEmail)
        {
           var list = await _hasPaymentInfoRepository.GetAllAsync();
           var entrepreneurHas = list.Where(h=>h.Entrepreneur_Email.Equals(entrepreneurEmail));
            if (entrepreneurHas == null)
            {
                return null;
            }
            return entrepreneurHas.ToList();
        }
        public async Task AddHasPaymentInfoAsync(HasPaymentInfo hasPaymentInfo)
        {
            await _hasPaymentInfoRepository.AddHasPaymentInfo(hasPaymentInfo);
        }
    }
}
