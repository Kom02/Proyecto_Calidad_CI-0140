using EmprendeUCR.Domain.Core.Entities;
using EmprendeUCR.Domain.Core.Exceptions;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmprendeUCR.Domain.PaymentMethods.Entities
{
    public partial class SinpeMovilPaymentMethod
    {
        public IReadOnlyCollection<SinpeMovilPaymentInfo> SinpeMovilPaymentInfos;
        private readonly List<SinpeMovilPaymentInfo> _sinpeMovilPaymentInfos;
        [Key]
        public string Name { get; private set; }
        public bool Status { get; private set; }
        public SinpeMovilPaymentMethod(string name, bool status)
        {
            Name = name;
            Status = status;
            _sinpeMovilPaymentInfos = new List<SinpeMovilPaymentInfo>();
        }
        public void ChangeStatus()
        {
            Status = !Status;
        }

        public void AddSinpeMovilPaymentInfo(SinpeMovilPaymentInfo sinpeMovilPaymentInfo)
        {
            if (_sinpeMovilPaymentInfos.Exists(p => p.Phone_Number == sinpeMovilPaymentInfo.Phone_Number))
                throw new DomainException("Ese número de teléfono ya se encuentra agregado");
            _sinpeMovilPaymentInfos.Add(sinpeMovilPaymentInfo);
            sinpeMovilPaymentInfo.AssignPaymentMethod(this);
        }

        public void RemovePhonePaymentInfo(SinpeMovilPaymentInfo sinpeMovilPaymentInfo)
        {
            if (_sinpeMovilPaymentInfos.Exists(p => p == sinpeMovilPaymentInfo))
            {
                _sinpeMovilPaymentInfos.Remove(sinpeMovilPaymentInfo);
                    sinpeMovilPaymentInfo.AssignPaymentMethod(null);
            }
        }
    }
}
