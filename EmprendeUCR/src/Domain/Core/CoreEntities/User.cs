using System;
using FluentValidation;

namespace EmprendeUCR.Domain.Core.CoreEntities
{
    public class User
    {
		public string Email { get; set; }
		public string Name { get; set; }
		public string F_Last_Name { get; set; }
		public string S_Last_Name { get; set; }
		public byte[] Photo { get; set; }
		public DateTime Birth_Date { get; set; } = DateTime.Now;
		public string Province_Name { get; set; } = "";
		public string Canton_Name { get; set; } = "";
		public string District_Name { get; set; } = "";
		public bool Email_Confirmation { get; set; } = false;
	}

    public class RegisterValidator : AbstractValidator<User>
    {
        public RegisterValidator()
        {
            // check name format
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Su nombre esta vacío")
                .Matches("^[a-zA-Z ]+$").WithMessage("Su nombre solo debe contener letras");

            // check last name format
            RuleFor(x => x.F_Last_Name)
                .NotEmpty().WithMessage("Su primer apellido esta vacío")
                .Matches("^[a-zA-Z ]+$").WithMessage("Su primer apellido solo debe contener letras");

            // check second last name format
            RuleFor(x => x.S_Last_Name)
                .NotEmpty().WithMessage("Su segundo apellido esta vacío")
                .Matches("^[a-zA-Z ]+$").WithMessage("Su segundo apellido solo debe contener letras");

            // check for valid birth date 18 >=
            RuleFor(x => x.Birth_Date)
                .Must(ValidAge).WithMessage("Debe tener al menos 18 años de edad");

        }

        protected bool ValidAge(DateTime date)
        {
            int currentYear = DateTime.Now.Year;
            int birthYear = date.Year;
            int age = currentYear - birthYear;

            // check that birth year is not in the future
            // check that birth year is not more than 120 years ago (dead person)
            // check that birth year is at least 18 year old
            if (birthYear <= currentYear && birthYear > (currentYear - 120) && age >= 18)
            {
                return true;
            }

            return false;
        }
    }
}
