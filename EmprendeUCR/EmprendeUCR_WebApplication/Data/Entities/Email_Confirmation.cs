using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

/*Agrega la tabla de Email_Confirmation para guardar datos de la confirmación de email en la tabla de datos*/
namespace EmprendeUCR_WebApplication.Data.Entities
{
    public class Email_Confirmation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Email { get; set; }
        public string Hash_Code { get; set; }
        public DateTime Creation_Date { get; set; }
        public DateTime Expiration_Date { get; set; }
    }
}
