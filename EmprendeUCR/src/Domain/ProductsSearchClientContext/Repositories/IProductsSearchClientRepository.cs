using EmprendeUCR.Domain.Core.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Domain.ProductsSearchClientContext.Repositories
{
    public interface IProductsSearchClientRepository
    {
        List<ProductPhotos> loadAllPhotos();
        Task<IList<Category>> getCategoriesAsync();
        IList<Product> getProductListByCategory(int categoryID);
        IList<Service> getServiceListByCategory(int categoryID);
        IList<Product> getListProductRestricted(string product, int categoryID);
        IList<Product> getListProduc(string product);
        Task changeCategoryParent(int Id, int? ParentId);
        bool isChildNode(int Id);
        Task<bool> searchProduct(string email, int idProduct);
        Task<bool> addProduct(ShoppingCartHas product);
        IList<Service> getListService(string product);
        IList<Service> GetListServiceRestricted(string product, int categoryID);
        IList<ProductService> GetProductService();
        IList<Service_Photos> getAllServicePhotos();
        IList<Product> GetProductPrice(int searchType);
        IList<Service> GetServiceByPrice(int searchType);

    }
}
