using EmprendeUCR.Domain.Core.Entities;
using EmprendeUCR.Domain.Core.Exceptions;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using LanguageExt;

namespace EmprendeUCR.Domain.PaymentMethods.Entities
{
    public partial class CardPaymentMethod
    {
        public IReadOnlyCollection<CardPaymentInfo> CardPaymentInfos;
        private readonly List<CardPaymentInfo> _cardPaymentInfos;
        [Key]
        public string Name { get; private set; }
        public bool Status { get; private set; }
        public CardPaymentMethod(string name, bool status)
        {
            Name = name;
            Status = status;
            _cardPaymentInfos = new List<CardPaymentInfo>();
        }
        public void ChangeStatus()
        {
            Status = !Status;
        }

        public Validation<ValidationError, string> AddCardPaymentInfo(CardPaymentInfo cardPaymentInfo)
        {
            if (_cardPaymentInfos.Exists(p => p.Account_Number == cardPaymentInfo.Account_Number))
            {
                throw new DomainException("Ese número de teléfono ya se encuentra agregado");
            }
            _cardPaymentInfos.Add(cardPaymentInfo);
            cardPaymentInfo.AssignPaymentMethod(this);
            return this.Name;
        }

        public Validation<ValidationError, string> RemovePhonePaymentInfo(CardPaymentInfo cardPaymentInfo)
        {
            if (_cardPaymentInfos.Exists(p => p == cardPaymentInfo))
            {
                _cardPaymentInfos.Remove(cardPaymentInfo);
                cardPaymentInfo.AssignPaymentMethod(null);
            }
            return new CardPaymentInfoNotFound();
        }
        public static Validation<ValidationError, string> TryCreateName(string? name) {

            if (name == "Visa")
                return name;
            else if (name == "MasterCard")
                return name;
            else
            {
                return new NameIsNotFound();
            }
        }
        public static Validation<ValidationError, bool> TryCreateValidStatus(bool status)
        {

            if (status == true )
                return status;
            else if (status == false)
                return  status;
            else
            {
                return new InvalidStatus();
            }
        }

        public abstract record ValidationError;
        public record NameIsNotFound : ValidationError;
        public record InvalidStatus : ValidationError;

        public record CardPaymentInfoNotFound : ValidationError;
    }
}
