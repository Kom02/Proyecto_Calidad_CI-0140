using Dapper;
using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Data.Services
{
    public class BannedAccountService : PageModel
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

        public BannedAccountService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }

        public async Task<IList<BannedAccount>> GetAsync() // Enlista Emprendedores
        {
            return await _context.Banned_Account.ToListAsync();
        }

        public void AddUser(BannedAccount Account)
        {
            _context.Banned_Account.Add(Account);
             _context.SaveChanges();
        }
    
        public BannedAccount GetUserByEmail(string email)
        {
          return _context.Banned_Account.Find(email);
        }


    }
}