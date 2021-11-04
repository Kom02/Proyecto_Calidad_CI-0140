using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentInfos.Entities;

namespace EmprendeUCR.Application.PaymentInfos
{
    public interface IHasPaymentInfoService
    {
        public Task<List<HasPaymentInfo>?> getHasPaymentInfoByEmail(string entrepreneurEmail);
        public Task AddHasPaymentInfoAsync(HasPaymentInfo hasPaymentInfo);
    }
}
