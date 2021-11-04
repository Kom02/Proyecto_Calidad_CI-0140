using EmprendeUCR.Domain.Core.Entities;
using FluentValidation;

namespace EmprendeUCR.Domain.RegisterContext.Entities
{
    public class Register : AggregateRoot
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterValidator : AbstractValidator<Register>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Su correo esta vacío")
                .EmailAddress().WithMessage("Dirección de correo electrónico no válida");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Su contraseña esta vacía")
                .MinimumLength(8).WithMessage("Su contraseña debe contener al menos 8 carácteres")
                .Matches("[a-z]+").WithMessage("Su contraseña debe contener al menos una letra minúscula")
                .Matches("[A-Z]+").WithMessage("Su contraseña debe contener al menos una letra mayúscula")
                .Matches("(\\d)+").WithMessage("Su contraseña debe contener al menos un número");
            
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Su confirmación de contraseña esta vacía")
                .Equal(x => x.Password).WithMessage("Sus contraseñas no coinciden");
        }
    }
}
