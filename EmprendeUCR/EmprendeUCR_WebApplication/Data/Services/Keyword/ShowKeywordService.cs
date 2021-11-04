using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Data.Entities;
using EmprendeUCR_WebApplication.Data.Entities.Keyword;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor.TreeGrid;

namespace EmprendeUCR_WebApplication.Data.Services.Keyword
{
    public class ShowKeywordService : PageModel
    {
        private readonly Contexts.SqlServerDbContext _context;
        public ShowKeywordService(Contexts.SqlServerDbContext context)
        {
            _context = context;
        }
        public async Task<List<Keywords>> GetAllkeywordsAsync()
        {
            return await _context.Keyword.ToListAsync();
        }
    }
}
