using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Reports.Entities;

namespace EmprendeUCR.Application.Reports
{
    public interface IReportService { 
        Task<IEnumerable<Report>> GetReportsAsync();
        Task<Report?> GetReportByIdAsync(int id);
        //Task ChangeStatusToPaymentMethodAsync(Report report);
        Task AddReportAsync(Report report);
        //Task DeleteReportAsync(Report report);
        Task SaveAsync();
    }
}