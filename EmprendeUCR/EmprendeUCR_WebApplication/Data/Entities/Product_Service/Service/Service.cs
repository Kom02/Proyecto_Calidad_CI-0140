using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
namespace EmprendeUCR_WebApplication.Data.Entities
{
    public class Service
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Code_ID { get; set; }
        public string Entrepreneur_Email { get; set; }
        public int Category_ID { get; set; }
        public string Service_Name { get; set; }
        public string Service_Description { get; set; }
        public int Price_per_hour { get; set; }
    }
    public class CreateValidatorService : AbstractValidator<Service>
    {
        public CreateValidatorService()
        {
            // check presentation format
            RuleFor(x => x.Service_Name)
                .NotEmpty().WithMessage("El nombre del servicio no puede estar vacio");
            RuleFor(x => x.Price_per_hour)
               .GreaterThanOrEqualTo(0).WithMessage("El precio debe ser mayor o igual a 0");
            RuleFor(x => x.Category_ID)
                .NotEmpty().WithMessage("Debe seleccionar una categoria");
        }
    }
}
