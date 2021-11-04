using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System;
using System.Linq;

namespace EmprendeUCR_WebApplication.Data.Services
{
    public class Shopping_CartService
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

        public Shopping_CartService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }

        public void addEmail(Shopping_Cart email)
        {
            _context.Add(email);
        }
    }
}
