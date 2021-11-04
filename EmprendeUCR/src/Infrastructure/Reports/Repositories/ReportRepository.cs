using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.Reports.Entities;
using EmprendeUCR.Domain.Reports.Repositories;
using EmprendeUCR.Infrastructure.Reports;
using Microsoft.EntityFrameworkCore;

namespace EmprendeUCR.Infrastructure.Reports.Repositories
{
    internal class ReportRepository : IReportRepository
    {
        private readonly ReportDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        public ReportRepository(ReportDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }
        public async Task<IEnumerable<Report>> GetAllAsync()
        {
            return await _dbContext.Report
            .Select(p => new Report(p.Title , p.Content, p.User,p.ID))
            .ToListAsync();
        }
        public async Task<Report?> GetByIdAsync(int ID)
        {
            return await _dbContext.Report
            .FirstOrDefaultAsync(p => p.ID == ID);
        }
        /// <summary>
        /// Saves aggregate and commits changes
        /// </summary>
        public async Task SaveAsync(Report report)
        {
            _dbContext.Update(report);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task AddReport(Report report)
        {
            await _dbContext.AddAsync(report);
            await _dbContext.SaveChangesAsync();
        }
    }
}