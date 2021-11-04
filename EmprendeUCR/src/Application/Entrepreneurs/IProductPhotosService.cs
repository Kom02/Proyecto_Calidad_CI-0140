
using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services;
using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Application.Entrepreneurs
{
    public interface IProductPhotosService
    {
        Task<List<ProductPhotos>> GetProductPhotosAsync();
        Task<ProductPhotos?> GetProductPhotoByIdAsync(long id);
        Task<List<ProductPhotos>> GetProductPhotosByCodeIDAsync(long id);
    }
}
