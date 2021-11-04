using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.ProductsSearchClientContext.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Infrastructure.ProductsSearchClientContext.Repositories
{
    public class ProductsSearchClientRepository : IProductsSearchClientRepository
    {
        private readonly ProductsSearchClientDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public ProductsSearchClientRepository(ProductsSearchClientDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<ProductPhotos> loadAllPhotos()
        {
            return _dbContext.ProductPhotos.ToList();
        }

        public async Task<IList<Category>> getCategoriesAsync()
        {
            return await _dbContext.Category.ToListAsync();
        }

        public IList<Product> getProductListByCategory(int categoryID)
        {
            return _dbContext.Product.FromSqlRaw("exec GetProductsByCategory " + categoryID).ToArray();
        }

        public IList<Service> getServiceListByCategory(int categoryID) 
        {
            return _dbContext.Service.FromSqlRaw("exec GetServicesByCategory " + categoryID).ToArray();
        }

        public IList<Product> getListProductRestricted(string product, int categoryID) 
        {
            return _dbContext.Product.FromSqlRaw("exec GetProductsRestricted \"" + product + "\"," + categoryID).ToArray();
        }

        public IList<Product> getListProduc(string product) 
        {
            return _dbContext.Product.FromSqlRaw("exec GetProducts \"" + product + "\"").ToArray();
        }

        public async Task changeCategoryParent(int Id, int? ParentId)
        {
            Category source = _dbContext.Category.Find(Id);
            source.ParentId = ParentId;
            _dbContext.Category.Update(source);
            await _dbContext.SaveChangesAsync();
        }

        public bool isChildNode(int Id)
        {
            bool isChild = false;
            if (_dbContext.Category.Where(c => c.ParentId.Equals(Id)).Count() == 0)
            {
                isChild = true;
            }
            return isChild;
        }

        public async Task<bool> searchProduct(string email, int idProduct)
        {
            ShoppingCartHas existing = await _dbContext.ShoppingCartHas.FirstOrDefaultAsync(c => c.Email.Equals(email) && c.Code_ID == idProduct);
            if (existing != null)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> addProduct(ShoppingCartHas product)
        {
            await _dbContext.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public IList<Service> getListService(string product)
        {
            return _dbContext.Service.FromSqlRaw("exec GetServices \"" + product + "\"").ToArray();
        }

        public IList<Service> GetListServiceRestricted(string product, int categoryID)
        {
            return _dbContext.Service.FromSqlRaw("exec GetServicesRestricted \"" + product + "\"," + categoryID).ToArray();
        }

        public IList<ProductService> GetProductService()
        {
            return  _dbContext.ProductService.ToList();
        }

        public IList<Service_Photos> getAllServicePhotos()
        {
            return _dbContext.Service_Photos.ToList();
        }

        public IList<Product> GetProductPrice(int searchType)
        {
            return _dbContext.Product.FromSqlRaw("exec getProductsByPrice \"" + searchType + "\"").ToArray();
        }

        public IList<Service> GetServiceByPrice(int searchType)
        {
            return _dbContext.Service.FromSqlRaw("exec getServicesByPrice \"" + searchType + "\"").ToArray();
        }
    }
}
