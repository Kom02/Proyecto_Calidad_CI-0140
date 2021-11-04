using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services;

namespace EmprendeUCR.Domain.EntrepreneurContext.Repositories
{
    public interface IProductServiceRepository
    {
        Task SaveAsync(Product_Service product_service);
        Task<List<Product_Service>> GetAllAsync();
        Task<Product_Service?> GetByIdAsync(long id);
    }
}
