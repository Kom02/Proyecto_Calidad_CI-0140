using EmprendeUCR.Domain.EntrepreneurContext.Repositories;
using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services;
using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Application.Entrepreneurs.Implementations
{
    class ProductPhotosService : IProductPhotosService
    {
        private readonly IProductPhotosRepository _productPhotosRepository;
        public ProductPhotosService(IProductPhotosRepository productPhotosRepository)
        {
            _productPhotosRepository = productPhotosRepository;
        }

        public async Task<ProductPhotos?> GetProductPhotoByIdAsync(long id)
        {
            return await _productPhotosRepository.GetByIdAsync(id);
        }


        public async Task<List<ProductPhotos>> GetProductPhotosAsync()
        {
            return await _productPhotosRepository.GetAllAsync();
        }

        public async Task<List<ProductPhotos>> GetProductPhotosByCodeIDAsync(long id)
        {
            return await _productPhotosRepository.GetAllByProductIDAsync(id);
        }
    }
}
