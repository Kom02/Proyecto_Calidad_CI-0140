using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Data.Entities
{
	public class Likes
	{
		[Key]
		public string Members_Email { get; set; }
		[Required]
		public int Category_Id { get; set; }
	}
}