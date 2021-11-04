using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace EmprendeUCR_WebApplication.Data.Services
{
    public class Serviceservice : PageModel
    {

        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

        public Serviceservice(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
        {
            _context = context;
        }

        public IList<ServicePandemic> GetList(string product)
        {
            return _context.ServicePandemic.FromSqlRaw("exec GetServices \"" + product + "\"").ToArray();
        }

        public IList<ServicePandemic> GetListByCategory(int categoryID)
        {
            return _context.ServicePandemic.FromSqlRaw("exec GetServicesByCategory " + categoryID).ToArray();
        }

        public IList<ServicePandemic> GetListRestricted(string product, int categoryID)
        {
            return _context.ServicePandemic.FromSqlRaw("exec GetServicesRestricted \"" + product + "\"," + categoryID).ToArray();
        }
    }
}
