using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Domain.HomePageClientContext.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Blazor.TreeGrid;
using Syncfusion.Blazor.Grids;

namespace EmprendeUCR.Application.HomePageClientContext.Implementations
{
    public class HomePageClientService : IHomePageClientService
    {
        private readonly IHomePageClientRepository _homePageClientRepository;
        private readonly IDisplayProductRepository _displayProductRepository;
        SfTreeGrid<Category> TreeGrid;

        public HomePageClientService(IHomePageClientRepository HomePageClientRepository, IDisplayProductRepository DisplayProductRepository)
        {
            _homePageClientRepository = HomePageClientRepository;
            _displayProductRepository = DisplayProductRepository;

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

        public IList<Product> listAllNewProducts() 
        {
            return _homePageClientRepository.getNewProducts();
        }
        public IList<Product> listAllNewOffer() 
        {
            return _homePageClientRepository.getOfferProducts();
        }
        public IList<Product> listAllNewRecomendedProducts(string userEmail) 
        {
            return _homePageClientRepository.getRecommendedProducts(userEmail);
        }

        public IList<ProductPhotos> listAllProductsPhotos() 
        {
            return _homePageClientRepository.loadAllPhotos();
        }

        public async Task<IList<Category>> getAllCategoriesAsync() 
        {
            return await _homePageClientRepository.getCategoriesAsync();
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
            await _homePageClientRepository.changeCategoryParent(Id, ParentId);
        }

        public bool verifyChildCategory(int id) 
        {
           return _homePageClientRepository.isChildNode(id);
        }

        public async Task<bool> searchProductById(string email, int idProduct)
        {
            return await _homePageClientRepository.searchProduct(email, idProduct);
        }

        public async Task<bool> addProductShoppingCart(ShoppingCartHas shoppingCart) 
        {
            return await _homePageClientRepository.addProduct(shoppingCart);
        }

        public async Task<IList<Offer>> GetAllOffersAsync()
        {
            return await _homePageClientRepository.GetOffers();
        }

        public async Task<List<ProductService>> GetAllProductsServicesAsync()
        {
            return await _homePageClientRepository.GetAllProducts();        // Listado 2
        }

        public IList<Product> listPurchasedProducts(string email)
        {
            return _homePageClientRepository.GetPurchasedProducts(email);
        }

       public  IList<Is_Offer> getIs_Offer()
        {
            return _homePageClientRepository.GetAllIs_Offer();
        }
        public async Task<Is_Offer> GetIs_OfferAsync(int Is_Offer_Id)
        {
            return await _homePageClientRepository.GetIs_OfferAsync(Is_Offer_Id);
        }
        public IList<Service_Photos> getServicePhotos()
        {
            return _homePageClientRepository.GetAllServicePhotos();
        }

        public string GetEntrepreneurNameByEmail(string email)
        {
            User user = _displayProductRepository.GetUserByEmail( email);
            if(user != null)
            {
                return user.Name + " " + user.F_Last_Name + " " + user.S_Last_Name;
            }
            else
            {
                return string.Empty;
            }
            
        }
        public List<Is_Offer> GetAllIs_OfferRelatedToOfferNOTAsync(Offer offer)
        {
            return _homePageClientRepository.GetAllIs_OfferRelatedToOfferNOTAsync(offer);
        }
    }
}


