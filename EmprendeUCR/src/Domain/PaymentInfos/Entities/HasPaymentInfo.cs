using EmprendeUCR.Domain.Core.Entities;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.Core.CoreEntities;
using System.ComponentModel.DataAnnotations;

namespace EmprendeUCR.Domain.PaymentInfos.Entities
{
    public partial class HasPaymentInfo
    {
        public string Entrepreneur_Email { get; set; }
        public int Payment_Info_ID { get; set; }
        public HasPaymentInfo(string entrepreneur_Email, int payment_Info_ID)
        {
            Entrepreneur_Email = entrepreneur_Email;
            Payment_Info_ID = payment_Info_ID;
        }
        public HasPaymentInfo() { }
    }
}

