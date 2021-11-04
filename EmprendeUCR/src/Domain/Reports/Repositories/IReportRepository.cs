using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Reports.Entities;

namespace EmprendeUCR.Domain.Reports.Repositories
{
    public interface IReportRepository 
    {
        Task SaveAsync(Report report);
        Task<IEnumerable<Report>> GetAllAsync();
        Task<Report?> GetByIdAsync(int id);
        //Task DeleteReport(Report report);
    }
}