using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Data.Services
{
    public class DistrictService : PageModel
    {
    	private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

    	public DistrictService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
    	{
    		_context = context;
    	}

    	public async Task<IList<District>> GetAsync()
    	{
    		return await _context.District.ToListAsync();
    	}

        public IList<District> GetList(string canton)
        {
            return _context.District.FromSqlRaw("exec GetDistricts @canton =\"" + canton +"\"").ToArray();
        }
    }
}
