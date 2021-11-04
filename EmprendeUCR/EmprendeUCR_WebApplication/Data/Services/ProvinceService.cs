using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Data.Services
{
    public class ProvinceService : PageModel
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

        public ProvinceService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Province>> GetAsync()
        {
            return await _context.Province.ToListAsync();
        }

        public IList<Province> GetProvinces()
        {
            return _context.Province.ToList();
        }

        public void addProvince(Province province)
        {
            _context.Province.Add(province);
            _context.SaveChanges();
        }
    }
}
