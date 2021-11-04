using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/*
    Shopping_Cart_Has: This cs file contains the class necessary to bring 
    information back from the shopping cart has sql table into our program.
 */

namespace EmprendeUCR_WebApplication.Data.Entities
{
    public class Shopping_Cart_Has
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Email { get; set; }
        public int Code_ID { get; set; }
        public string Entrepreneur_Email { get; set; }
        public int Category_ID { get; set; }
    }
}
