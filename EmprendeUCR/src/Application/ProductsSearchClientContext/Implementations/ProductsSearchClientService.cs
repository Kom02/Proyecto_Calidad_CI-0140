using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Domain.ProductsSearchClientContext.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Blazor.TreeGrid;
using Syncfusion.Blazor.Grids;

namespace EmprendeUCR.Application.ProductsSearchClientContext.Implementations
{
    public class ProductsSearchClientService : IProductsSearchClientService
    {
        private readonly IProductsSearchClientRepository _productsSearchClientRepository;
        SfTreeGrid<Category> TreeGrid;

        public ProductsSearchClientService(IProductsSearchClientRepository ProductsSearchClientRepository)
        {
            _productsSearchClientRepository = ProductsSearchClientRepository;
        }

        public string convertImageDisplay(byte[] image)
        {
            if (image != null)
            {
                var base64 = Convert.ToBase64String(image);
                var fs = string.Format("data:image/jpg;base64,{0}", base64);
                return fs;
            }
            return "";
        }

        public List<ProductPhotos> listAllProductsPhotos()
        {
            return _productsSearchClientRepository.loadAllPhotos();
        }

        public async Task<IList<Category>> getAllCategoriesAsync()
        {
            return await _productsSearchClientRepository.getCategoriesAsync();
        }

        public IList<Product> getProductsListByCategoryId(int categoryID) 
        {
            return _productsSearchClientRepository.getProductListByCategory(categoryID);
        }

        public IList<Service> getServicesListByCategoryId(int categoryID) 
        {
            return _productsSearchClientRepository.getServiceListByCategory(categoryID);
        }

        public IList<Product> getListProductsRestricted(string product, int categoryID) 
        {
            return _productsSearchClientRepository.getListProductRestricted(product, categoryID);
        }

        public IList<Product> getListProducs(string product)
        {
            return _productsSearchClientRepository.getListProduc(product);
        }

        public async Task Rowdrop(Syncfusion.Blazor.Grids.RowDragEventArgs<Category> args, SfTreeGrid<Category> main)
        {
            this.TreeGrid = main;
            var position = args.Target.ID;
            if (position == " e-dropchild")
            {
                var CurrentViewData = this.TreeGrid.GetCurrentViewRecords();
                var TargetCategory = CurrentViewData.ElementAt((int)args.DropIndex);
                var SourceCategory = CurrentViewData.ElementAt((int)args.FromIndex);
                await ChangeParent(SourceCategory.Id, TargetCategory.ParentId);
            }
            else
            {
                args.Cancel = true;
            }
        }

        public async Task ChangeParent(int Id, int? ParentId)
        {
            await _productsSearchClientRepository.changeCategoryParent(Id, ParentId);
        }

        public bool verifyChildCategory(int id)
        {
            return _productsSearchClientRepository.isChildNode(id);
        }

        public async Task<bool> searchProductById(string email, int idProduct)
        {
            return await _productsSearchClientRepository.searchProduct(email, idProduct);
        }

        public async Task<bool> addProductShoppingCart(ShoppingCartHas shoppingCart)
        {
            return await _productsSearchClientRepository.addProduct(shoppingCart);
        }

        public IList<Service> getListServices(string product) 
        {
            return  _productsSearchClientRepository.getListService(product);
        }

        public IList<Service> getListServicesRestricted(string product, int categoryID)
        {
            return _productsSearchClientRepository.GetListServiceRestricted(product, categoryID);
        }

        public IList<ProductService> GetAllProductsServicesAsync()
        {
            return _productsSearchClientRepository.GetProductService();
        }

        public IList<Service_Photos> getServicePhotos()
        {
            return _productsSearchClientRepository.getAllServicePhotos();
        }

        public IList<Product> GetProductsByPrice(int searchType)
        {
            return _productsSearchClientRepository.GetProductPrice(searchType);
        }

        public IList<Service> GetServicesByPrice(int searchType)
        {
            return _productsSearchClientRepository.GetServiceByPrice(searchType);
        }
    }
}
