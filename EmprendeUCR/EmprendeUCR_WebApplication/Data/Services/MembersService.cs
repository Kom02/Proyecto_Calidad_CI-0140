using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Data.Services
{
    public class MembersService : PageModel
    {
    	private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

    	public MembersService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
    	{
    		_context = context;
    	}

        public async Task<IList<Members>> GetAsync()
        {
            return await _context.Members.ToListAsync();
        }

        public void AddMembers(Members members)
        {
            _context.Members.Add(members);
            _context.SaveChanges();
        }

        public async Task<Members> GetByEmailAsync(string email)
        {
            var a = (await _context.Members.FindAsync(email));
            return a;
        }

        public async Task<bool> UpdateAsync(Members member)
        {
             _context.Members.Update(member);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}