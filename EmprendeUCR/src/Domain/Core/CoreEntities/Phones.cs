using FluentValidation;

namespace EmprendeUCR.Domain.Core.CoreEntities
{
    public class Phones
    {
        public string User_Email { get; set; }
        public string Phone_Number { get; set; }
    }


    public class RegisterValidatorPhones : AbstractValidator<Phones>
    {
        public RegisterValidatorPhones()
        {
            // check phone format
            RuleFor(x => x.Phone_Number)
                .Length(8).WithMessage("Ingrese un número de teléfono válido de 8 digitos")
                .Matches("^[0-9]*$").WithMessage("Su número de teléfono solo debe contener digitos");
        }
    }

}
