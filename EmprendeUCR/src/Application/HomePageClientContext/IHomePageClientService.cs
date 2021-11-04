using EmprendeUCR.Domain.Core.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Blazor.TreeGrid;

namespace EmprendeUCR.Application.HomePageClientContext
{
    public interface IHomePageClientService
    {
        string convertImageDisplay(byte[] image);
        IList<Product> listAllNewProducts();
        IList<Product> listAllNewOffer();
        IList<Product> listAllNewRecomendedProducts(string userEmail);
        IList<ProductPhotos> listAllProductsPhotos();
        Task<IList<Category>> getAllCategoriesAsync();
        Task Rowdrop(Syncfusion.Blazor.Grids.RowDragEventArgs<Category> args, SfTreeGrid<Category> main);
        Task ChangeParent(int Id, int? ParentId);
        bool verifyChildCategory(int id);
        Task<bool> searchProductById(string email, int idProduct);
        Task<bool> addProductShoppingCart(ShoppingCartHas shoppingCart);
        Task<IList<Offer>> GetAllOffersAsync();
        Task<List<ProductService>> GetAllProductsServicesAsync();
        IList<Product> listPurchasedProducts(string email);

        IList<Is_Offer> getIs_Offer();
        IList<Service_Photos> getServicePhotos();
        String GetEntrepreneurNameByEmail(string email);
        Task<Is_Offer> GetIs_OfferAsync(int Is_Offer_Id);
        List<Is_Offer> GetAllIs_OfferRelatedToOfferNOTAsync(Offer offer);


    }
}