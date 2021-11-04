using EmprendeUCR.Domain.EntrepreneurContext.Repositories;
using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Application.Entrepreneurs.Implementations
{
    class ProductServiceService : IProductServiceService
    {
        private readonly IProductServiceRepository _productServiceRepository;
        public ProductServiceService(IProductServiceRepository productServiceRepository)
        {
           _productServiceRepository = productServiceRepository;
        }

        public async Task<Product_Service> GetProducServiceByIdAsync(long id)
        {
            return await _productServiceRepository.GetByIdAsync(id);
        }


        public async Task<List<Product_Service>> GetProductServicesAsync()
        {
            return await _productServiceRepository.GetAllAsync();
        }
    }
}
