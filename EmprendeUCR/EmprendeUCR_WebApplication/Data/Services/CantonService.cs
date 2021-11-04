using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Data.Services
{
    public class CantonService : PageModel
    {
    	private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

    	public CantonService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
    	{
    		_context = context;
    	}

        public async Task<IList<Canton>> GetAsync()
        {
            return await _context.Canton.ToListAsync();
        }

    	public IList<Canton> GetList(string province)
    	{
            return _context.Canton.FromSqlRaw("exec GetCantons @province =\"" + province+"\"").ToArray();
    	}
    }
}