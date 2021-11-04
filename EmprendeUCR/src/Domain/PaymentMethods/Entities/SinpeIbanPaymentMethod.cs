using EmprendeUCR.Domain.Core.Entities;
using EmprendeUCR.Domain.Core.Exceptions;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmprendeUCR.Domain.PaymentMethods.Entities
{
    public partial class SinpeIbanPaymentMethod
    {
        public IReadOnlyCollection<SinpeIbanPaymentInfo> SinpeIbanPaymentInfos;
        private readonly List<SinpeIbanPaymentInfo> _sinpeIbanPaymentInfos;
        [Key]
        public string Name { get; private set; }
        public bool Status { get; private set; }
        public SinpeIbanPaymentMethod(string name, bool status)
        {
            Name = name;
            Status = status;
            _sinpeIbanPaymentInfos = new List<SinpeIbanPaymentInfo>();
        }
        public void ChangeStatus()
        {
            Status = !Status;
        }
        public void AddSinpeIbanPaymentInfo(SinpeIbanPaymentInfo sinpeIbanPaymentInfo)
        {
            if (_sinpeIbanPaymentInfos.Exists(p => p.Account_Number == sinpeIbanPaymentInfo.Account_Number))
                throw new DomainException("Ese número de teléfono ya se encuentra agregado");
            _sinpeIbanPaymentInfos.Add(sinpeIbanPaymentInfo);
            sinpeIbanPaymentInfo.AssignPaymentMethod(this);
        }

        public void RemovePhonePaymentInfo(SinpeIbanPaymentInfo sinpeIbanPaymentInfo)
        {
            if (_sinpeIbanPaymentInfos.Exists(p => p == sinpeIbanPaymentInfo))
            {
                _sinpeIbanPaymentInfos.Remove(sinpeIbanPaymentInfo);
                sinpeIbanPaymentInfo.AssignPaymentMethod(null);
            }
        }
    }
}
