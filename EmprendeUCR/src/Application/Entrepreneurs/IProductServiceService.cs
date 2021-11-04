using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Application.Entrepreneurs
{
    public interface IProductServiceService
    {
        Task<List<Product_Service>> GetProductServicesAsync();
        Task<Product_Service?> GetProducServiceByIdAsync(long id);
    }
}
