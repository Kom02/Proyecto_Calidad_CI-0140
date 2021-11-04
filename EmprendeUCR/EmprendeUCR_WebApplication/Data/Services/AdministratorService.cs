using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmprendeUCR_WebApplication.Data.Services
{
    public class AdministratorService:PageModel
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

        public AdministratorService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }

        public void AddAdministrator(Administrator administrator)
        {
            _context.Administrator.Add(administrator);
            _context.SaveChanges();
        }

        public async Task<Administrator> GetByEmailAsync(string email)
        {
            return await _context.Administrator.FindAsync(email);
        }

        public async Task<bool> UpdateAsync(Administrator admin)
        {
            _context.Administrator.Update(admin);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
