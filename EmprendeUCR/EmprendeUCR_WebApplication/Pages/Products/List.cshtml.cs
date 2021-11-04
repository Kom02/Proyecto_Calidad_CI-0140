using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmprendeUCR_WebApplication.Data.Contexts;
using EmprendeUCR_WebApplication.Data.Entities;

namespace EmprendeUCR_WebApplication.Pages.Products
{
    public class ListModel : PageModel
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

        public ListModel(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }

        public IList<EmprendeUCR_WebApplication.Data.Entities.Product> Product { get; set; }

        public async Task OnGetAsync()
        {

            Product = (IList<EmprendeUCR_WebApplication.Data.Entities.Product>)await _context.Product.ToListAsync();
        }
    }
}
