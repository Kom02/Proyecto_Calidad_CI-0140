using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor.TreeGrid;
using EmprendeUCR.Domain.Reports.Entities;

namespace EmprendeUCR_WebApplication.Data.Services
{
    public class ReportService : PageModel
    {
        private readonly Contexts.SqlServerDbContext _context;

        public ReportService(Contexts.SqlServerDbContext context)
        {
            _context = context;
        }

        /**
        * @brief asyncronously returns a list of the current existing Reports
        * @param
        * @return await _context.Category.ToListAsync(), returns the list of existing Reports
        */
        public async Task<IList<Report>> GetAsync()
        {
            return await _context.Report.ToListAsync();
        }
        public Report getReportById(int Id)
        {
            return _context.Report.Find(Id);
        }

        public void deleteReport(Report report) {
            _context.Report.Remove(report);
            _context.SaveChanges();
        }
    }
}