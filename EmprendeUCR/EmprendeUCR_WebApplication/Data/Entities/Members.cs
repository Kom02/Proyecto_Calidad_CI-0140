using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Data.Entities
{
	public class Members
	{

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
		public string User_Email { get; set; }
        public int Score { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Direction { get; set; }
	}
}