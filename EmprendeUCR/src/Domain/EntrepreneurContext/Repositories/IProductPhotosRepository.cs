using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services.Products;

namespace EmprendeUCR.Domain.EntrepreneurContext.Repositories
{
    public interface IProductPhotosRepository
    {
        Task SaveAsync(ProductPhotos ProductPhotos);
        Task<List<ProductPhotos>> GetAllAsync();
        Task<ProductPhotos?> GetByIdAsync(long id);
        Task<List<ProductPhotos>> GetAllByProductIDAsync(long id);

    }
}
