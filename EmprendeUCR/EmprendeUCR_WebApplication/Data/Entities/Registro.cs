using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Data.Entities
{
    public class Registro
    {

        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "El correo electrónico es necesario")]
        [EmailAddress(ErrorMessage = "Correo electrónico inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contraseña requerida")]
        [StringLength(255, ErrorMessage = "La contraseña debe ser minimo de 5 caracteres y máximo 255", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Es requerido confirmar la contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
