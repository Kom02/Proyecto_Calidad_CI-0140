using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Data.Entities
{
    public class Product
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Code_ID { get; set; }
        public string Entrepreneur_Email { get; set; }
        [Required]
        public int Category_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        [Required]
        public int Price { get; set; }

    }
    public class CreateValidatorProduct : AbstractValidator<Product>
    {
        public CreateValidatorProduct()
        {
            // check presentation format
            RuleFor(x => x.Product_Name)
                .NotEmpty().WithMessage("El nombre del producto no puede estar vacio");
            RuleFor(x => x.Price)
               .GreaterThan(0).WithMessage("El precio debe ser mayor a 0");
            RuleFor(x => x.Price)
               .NotEmpty().WithMessage("El precio no puede estar vacio");
            RuleFor(x => x.Category_ID)
                .NotEmpty().WithMessage("Debe seleccionar una categoria");
        }
    }
}


