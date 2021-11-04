using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Data.Services
{
    public class LoginService : PageModel
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;
        public LoginService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }

        public bool VerifyUser(string email, int tipo)
        {
            bool res = false;
            switch (tipo)
            {
                case 1:

                    if (_context.Client.Find(email) != null)
                    {
                        res = true;
                    }
                    break;
                
                case 2:
                    if (_context.Entrepreneur.Find(email) != null)
                    {
                        res = true;
                    }
                    break;
                
                case 3:
                    if (_context.Administrator.Find(email) != null)
                    {
                        res = true;
                    }
                    break;
                
            }
            return res;
        }
    }
}
