using FluentValidation;

namespace EmprendeUCR.Domain.Core.CoreEntities
{
    public class Members
    {
        public string User_Email { get; set; }
        public int Score { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Direction { get; set; }
    }


    public class RegisterValidatorDirection : AbstractValidator<Members>
    {
        public RegisterValidatorDirection()
        {
            // check exact direction
            RuleFor(x => x.Direction)
                .NotEmpty().WithMessage("Dirección exacta esta vacía");
        }
    }

}