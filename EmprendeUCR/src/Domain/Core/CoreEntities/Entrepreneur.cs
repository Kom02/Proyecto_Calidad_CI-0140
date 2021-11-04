using FluentValidation;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using System.Collections.Generic;

namespace EmprendeUCR.Domain.Core.CoreEntities
{
    public class Entrepreneur
    {
        public string User_Email { get; set; }
        public string Presentation { get; set; }


        private readonly List<HasPaymentInfo> _hasPaymentInfoList;
        public IReadOnlyCollection<HasPaymentInfo> HasPaymentInfoList;
    }

    public class RegisterValidatorEntrepeneur : AbstractValidator<Entrepreneur>
    {
        public RegisterValidatorEntrepeneur()
        {
            // check presentation format
            RuleFor(x => x.Presentation)
                .NotEmpty().WithMessage("Su presentación esta vacía");
        }
    }
}
