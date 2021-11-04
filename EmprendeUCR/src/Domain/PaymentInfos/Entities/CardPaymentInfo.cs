using EmprendeUCR.Domain.PaymentMethods.Entities;
using System.ComponentModel.DataAnnotations;
using LanguageExt;

namespace EmprendeUCR.Domain.PaymentInfos.Entities
{
    public partial class CardPaymentInfo
    {
        public const int MinLength_Payment_Name = 1;
        public const int MaxLength_Payment_Name = 30;
        public const int Account_Number_Length = 22;

        public CardPaymentMethod CardPaymentMethod;
        [Key]
        public string Account_Number { get; private set; }
        public int Payment_Info_ID { get; private set; }
        public string? Name_Payment_Method { get; private set; }
        public CardPaymentInfo(string accountNumber, int paymentInfoID, string paymentMethodName)
        {
            Account_Number = accountNumber;
            Payment_Info_ID = paymentInfoID;
            Name_Payment_Method = paymentMethodName;
        }
        public CardPaymentInfo()
        {
            Account_Number = "";
            Payment_Info_ID = 0;
            Name_Payment_Method = null;
        }
        public void AssignPaymentMethod(CardPaymentMethod cardPaymentMethod)
        {
            CardPaymentMethod = cardPaymentMethod;
        }

        public static Validation<ValidationError, string> TryCreate(string? name)
        {
            if (name is null)
                return new NameIsNull();

            if (name.Length == 0)
                return new NameTooSmall(MinLength_Payment_Name);

            if (name.Length > MaxLength_Payment_Name)
                return new NameTooBig(MaxLength_Payment_Name);

            return name;
        }
        public static Validation<ValidationError, string> TryCreateAccount(string? account)
        {
            if (account is null)
                return new AccountNull();

            if (account.Length != Account_Number_Length)
                return new AccountInvalid(Account_Number_Length);

            return account;
        }
        public abstract record ValidationError;
        public record NameIsNull : ValidationError;
        public record NameTooSmall(int MinLenght) : ValidationError;
        public record NameTooBig(int MaxLength) : ValidationError;
        public record AccountNull : ValidationError;
        public record AccountInvalid(int MinLenght) : ValidationError;
    }
}

