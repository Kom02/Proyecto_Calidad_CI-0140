using EmprendeUCR.Domain.Core.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Blazor.TreeGrid;

namespace EmprendeUCR.Application.ProductsSearchClientContext
{
    public interface IProductsSearchClientService
    {
        string convertImageDisplay(byte[] image);
        List<ProductPhotos> listAllProductsPhotos();
        Task<IList<Category>> getAllCategoriesAsync();
        IList<Product> getProductsListByCategoryId(int categoryID);
        IList<Service> getServicesListByCategoryId(int categoryID);
        IList<Product> getListProductsRestricted(string product, int categoryID);
        IList<Product> getListProducs(string product);
        Task Rowdrop(Syncfusion.Blazor.Grids.RowDragEventArgs<Category> args, SfTreeGrid<Category> main);
        Task ChangeParent(int Id, int? ParentId);
        bool verifyChildCategory(int id);
        Task<bool> searchProductById(string email, int idProduct);
        Task<bool> addProductShoppingCart(ShoppingCartHas shoppingCart);
        IList<Service> getListServices(string product);
        IList<Service> getListServicesRestricted(string product, int categoryID);
        IList<ProductService> GetAllProductsServicesAsync();

        IList<Service_Photos> getServicePhotos();
        IList<Product> GetProductsByPrice(int searchType);

        IList<Service> GetServicesByPrice(int searchType);
    }
}
