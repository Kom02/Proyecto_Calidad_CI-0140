using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprendeUCR_WebApplication.Data.Entities
{
	public class BannedAccount
	{
		[Key]
		public string UserEmail { get; set; }
		public DateTime BeginDate { get; set; }
		public DateTime FinishDate { get; set; }
		public int Type { get; set; }
	}
}
