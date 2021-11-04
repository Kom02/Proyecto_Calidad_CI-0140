using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmprendeUCR.Domain.PaymentInfos.Entities
{
    public partial class PaymentInfo
    {
        [Key]
        public int ID { get; private set; }

        public PaymentInfo(int id)
        {
            ID = id; 
        }
        public PaymentInfo()
        {
            ID = 0;
        }

        private readonly List<HasPaymentInfo> _hasPaymentInfoList;
        public IReadOnlyCollection<HasPaymentInfo> HasPaymentInfoList;
    }
}

