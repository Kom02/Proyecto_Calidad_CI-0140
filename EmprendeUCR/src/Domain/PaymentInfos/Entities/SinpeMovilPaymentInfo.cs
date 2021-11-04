using EmprendeUCR.Domain.Core.Entities;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using System.ComponentModel.DataAnnotations;

namespace EmprendeUCR.Domain.PaymentInfos.Entities
{
    public partial class SinpeMovilPaymentInfo
    {
        public SinpeMovilPaymentMethod SinpeMovilPaymentMethod;
        [Key]
        public int Phone_Number { get; private set; }
        public int Payment_Info_ID { get; private set; }
        public string? Name_Payment_Method { get; private set; }
        public SinpeMovilPaymentInfo(int phoneNumber, int paymentInfoID, string paymentMethodName)
        {
            Phone_Number = phoneNumber;
            Payment_Info_ID = paymentInfoID;
            Name_Payment_Method = paymentMethodName;
        }
        public SinpeMovilPaymentInfo()
        {
            Phone_Number = 0;
            Payment_Info_ID = 0;
            Name_Payment_Method = null;
        }
        public void AssignPaymentMethod(SinpeMovilPaymentMethod sinpeMovilPaymentMethod)
        {
            SinpeMovilPaymentMethod = sinpeMovilPaymentMethod;
        }
    }
}

