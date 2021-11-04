using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprendeUCR_WebApplication.Data.Entities
{
	public class User
	{
		[Key]
		[Required]
		public string Email { get; set; }
		[StringLength(15)]
		public string Name { get; set; }
		[StringLength(15)]
		public string F_Last_Name { get; set; }
		[StringLength(15)]
		public string S_Last_Name { get; set; }
		public byte[] Photo { get; set; }
		public DateTime Birth_Date { get; set; } = DateTime.Now;
		public string Province_Name { get; set; } = "";
		public string Canton_Name { get; set; } = "";
		public string District_Name { get; set; } = "";
		public bool Email_Confirmation { get; set; } = false;
	}
}
