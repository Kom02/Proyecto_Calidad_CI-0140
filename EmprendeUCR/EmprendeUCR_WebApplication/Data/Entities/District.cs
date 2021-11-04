using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Data.Entities
{
    public class District
    {
    	[Key]
    	public string Name { get; set; }
        [Required]
    	public string Province_Name { get; set; }
        [Required]
    	public string Canton_Name { get; set; }
    }
}
