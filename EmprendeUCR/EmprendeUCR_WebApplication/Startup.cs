using EmprendeUCR_WebApplication.Data;
using EmprendeUCR_WebApplication.Data.Contexts;
using EmprendeUCR_WebApplication.Data.Entities;
using EmprendeUCR_WebApplication.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Data.Services.Categories;
using EmprendeUCR_WebApplication.Data.Services.Keyword;
using Syncfusion.Blazor;
using EmprendeUCR.Application;
using EmprendeUCR.Infrastructure;
using Blazored.SessionStorage;

using EmprendeUCR_WebApplication.Application.ShoppingCartContext;
using EmprendeUCR_WebApplication.Infrastructure.Core;

using EmprendeUCR_WebApplication.Domain.Repositories;

using EmprendeUCR_WebApplication.Application.ShoppingCartContext.Implementations;
using EmprendeUCR_WebApplication.Infrastructure.ShoppingCartContext;

using EmprendeUCR_WebApplication.Application.OrderContext.Implementations;
using EmprendeUCR_WebApplication.Application.OrderContext;
using EmprendeUCR_WebApplication.Infrastructure.OrderContext;
using EmprendeUCR_WebApplication.Infrastructure.OrderContext.Repositories;
using EmprendeUCR.Application.Reports.Implementations;
using EmprendeUCR.Application.LoginContext;
using EmprendeUCR.Infrastructure.LoginContext;
using EmprendeUCR.Domain.LoginContext;
using EmprendeUCR.Domain.LoginContext.Repositories;
using EmprendeUCR.Infrastructure.LoginContext.Repositories;
using EmprendeUCR.Application.LoginContext.Implementations;
using EmprendeUCR_WebApplication.Application.NotificationContext.Implementations;
using EmprendeUCR_WebApplication.Application.NotificationContext;
using EmprendeUCR_WebApplication.Infrastructure.NotificationContext;
using EmprendeUCR_WebApplication.Infrastructure.NotificationContext.Repositories.Handlers;

using EmprendeUCR.Infrastructure.ProfileContext;
using EmprendeUCR.Domain.ProfileContext.Repositories;
using EmprendeUCR.Infrastructure.ProfileContext.Repositories;

using EmprendeUCR.Domain.HomePageClientContext.Repositories;
using EmprendeUCR.Infrastructure.HomePageClientContext;
using EmprendeUCR.Infrastructure.HomePageClientContext.Repositories;
using EmprendeUCR.Domain.RegisterContext.Repositories;
using EmprendeUCR.Infrastructure.RegisterContext.Repositories;
using EmprendeUCR.Infrastructure.RegisterContext;
using EmprendeUCR.Domain.ProductsSearchClientContext.Repositories;
using EmprendeUCR.Infrastructure.ProductsSearchClientContext.Repositories;
using EmprendeUCR.Infrastructure.ProductsSearchClientContext;
using EmprendeUCR.Domain.ConfirmAdminContext.Repositories;
using EmprendeUCR.Infrastructure.ConfirmAdminContext.Repositories;
using EmprendeUCR.Infrastructure.ConfirmAdminContext;
using EmprendeUCR_WebApplication.Application.BillContext;
using EmprendeUCR_WebApplication.Application.BillContext.Implementations;
using EmprendeUCR_WebApplication.Infrastructure.BillContext.Implementations;
using EmprendeUCR_WebApplication.Infrastructure.BillContext;
using EmprendeUCR_WebApplication.Infrastructure.Core.OfferContext.Repositories;
using EmprendeUCR_WebApplication.Infrastructure.Core.OfferContext;
using EmprendeUCR.Domain.PermissionContext.Repositories;
using EmprendeUCR.Infrastructure.PermissionContext.Repositories;
using EmprendeUCR.Infrastructure.PermissionContext;

using EmprendeUCR.Application.Reports;
namespace EmprendeUCR_WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ShoppingCartDbContext2>(options =>
            {
                options.UseSqlServer((Configuration.GetConnectionString("DefaultConnection")));
                options.EnableSensitiveDataLogging();
            });
              
            services.AddDbContext<SqlServerDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
            });

            services.AddDbContext<OrderDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
            });
            services.AddDbContext<OfferDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));



            ////////////CLEAN ARCHITECTURE PANDEMIC PLAN
            ///REPOSITORIES AND SERVICES

            services.AddTransient<EmprendeUCR.Application.LoginContext.ILoginService, EmprendeUCR.Application.LoginContext.Implementations.LoginService>();
            services.AddTransient<ILoginRepository, LoginRepository>();

            services.AddTransient<EmprendeUCR.Application.HomePageClientContext.IHomePageClientService, EmprendeUCR.Application.HomePageClientContext.Implementations.HomePageClientService>();
            services.AddTransient<IHomePageClientRepository, HomePageClientRepository>();
            services.AddTransient<IDisplayProductRepository, DisplayProductRepository>();

            services.AddTransient<EmprendeUCR.Application.RegisterContext.IRegisterService, EmprendeUCR.Application.RegisterContext.Implementations.RegisterService>();
            services.AddTransient<IRegisterRepository, RegisterRepository>();
            //services.AddTransient<EmprendeUCR.Application.Reports.IReportService, EmprendeUCR.Application.Reports.Implementations.CreateReportService>();
            //services.AddTransient<IReportService,CreateReportService>();

            services.AddTransient<EmprendeUCR.Application.ProductsSearchClientContext.IProductsSearchClientService, EmprendeUCR.Application.ProductsSearchClientContext.Implementations.ProductsSearchClientService>();
            services.AddTransient<IProductsSearchClientRepository, ProductsSearchClientRepository>();

            services.AddTransient<EmprendeUCR.Application.ProfileContext.IProfileService, EmprendeUCR.Application.ProfileContext.Implementations.ProfileService>();
            services.AddTransient<IProfileRepository, ProfileRepository>();

            services.AddTransient<EmprendeUCR.Application.ConfirmAdminContext.IConfirmAdminService, EmprendeUCR.Application.ConfirmAdminContext.Implementations.ConfirmAdminService>();
            services.AddTransient<IConfirmAdminRepository, ConfirmAdminRepository>();

            // Clean arquitecture 3DKR
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddApplicationLayer();
            services.AddInfrastructureLayer(
                Configuration.GetConnectionString("SqlConnection"));

            services.AddTransient<EmprendeUCR.Application.PermissionContext.IPermissionService, EmprendeUCR.Application.PermissionContext.Implementations.PermissionService>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();

            ///////////////DBCONTEXT PANDEMIC PLAN

            services.AddDbContext<LoginDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<DisplayProductDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<ConfirmAdminDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<HomePageClientDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<RegisterDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<ProductsSearchClientDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<ProfileDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<PermissionDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            ////////////////////////////////
            services.AddDbContext<NotificationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            /*Contexto Pandemic*/
            services.AddDbContext<SqlDbContextPandemic>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            /*Contexto General*/
            services.AddDbContext<SqlServerDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddIdentity<UserService, IdentityRole>().AddEntityFrameworkStores<BookStoreContext>().AddDefaultTokenProviders();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSyncfusionBlazor();
            services.AddScoped<Alliance_Service>();
            services.AddScoped<CategoryService>();
            services.AddScoped<AddCategoryService>();
            services.AddScoped<DeleteCategoryService>();
            services.AddScoped<EditCategoryService>();
            services.AddScoped<ProductService>();
            services.AddScoped<EntrepreneurService>();
            services.AddScoped<UserService>();
            services.AddScoped<Product_ServiceService>();
            services.AddScoped<Shopping_Cart_HasService>();
            services.AddScoped<ProvinceService>();
            services.AddScoped<CantonService>();
            services.AddScoped<DistrictService>();
            services.AddScoped<CredentialsService>();
            services.AddScoped<LikesService>();
            services.AddScoped<ClientService>();
            services.AddScoped<MembersService>();
            services.AddScoped<RegisterService>();
            services.AddScoped<MailService>();
            services.AddScoped<Email_ConfirmationService>();
            services.AddScoped<AdministratorService>();
            services.AddScoped<EncrypService>();
            //services.AddScoped<LoginService>();
            services.AddBlazoredSessionStorage();
            services.AddScoped<PhonesService>();
            services.AddScoped<Shopping_CartService>();

            services.AddScoped<Product_PhotosService>();

            services.AddScoped<Shopping_Cart_Has_Service_Pandemic>();

            services.AddScoped<Serviceservice>();

            services.AddScoped<KeywordService>();
            services.AddScoped<AddKeywordService>();
            services.AddScoped<ShowKeywordService>();
            services.AddScoped<KeywordServiceService>();
            services.AddScoped<HasKeywordService>();
            services.AddScoped<HasKeywordServiceService>();

            services.AddBlazoredSessionStorage();

            /*Servicios Pandemic*/
            services.AddScoped<UserServicePandemic>();
            services.AddScoped<ProductServicePandemic>();


            Global.ConnectionString = Configuration.GetConnectionString("SqlConnection");
            Global.DomainName = Configuration["DomainName"];
            services.AddScoped<CredentialsService>();
            services.AddScoped<LikesService>();
            services.AddScoped<ClientService>();
            services.AddScoped<MembersService>();
            services.AddScoped<RegisterService>();
            services.AddScoped<MailService>();
            services.AddScoped<Email_ConfirmationService>();
            services.AddScoped<AdministratorService>();
            services.AddScoped<EncrypService>();
            //services.AddScoped<LoginServiceA>();
            services.AddBlazoredSessionStorage();
            services.AddScoped<BannedAccountService>();
            Global.ConnectionString = Configuration.GetConnectionString("SqlConnection");
            Global.DomainName = Configuration["DomainName"];
            services.AddScoped <CredentialsService>();
            services.AddScoped<OfferService>();
            services.AddScoped<Is_OfferService>();
            services.AddScoped<ServiceService>();
            services.AddScoped<Product_PhotosService>();
            services.AddScoped<Service_PhotosService>();
            services.AddScoped<HasSuppliesService>();
            services.AddScoped<Has_StatusService>();
            services.AddScoped<OrderService>();
            services.AddScoped<StatusService>();
            services.AddScoped<Personalized_StatusService>();
            //services.AddScoped<ServiceService>();
            services.AddScoped<SuggestedCategoryService>();
            services.AddScoped<ReportService>();



            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

            services.AddTransient<IShoppingCartService, ShoppingCartService>();


            services.AddApplicationLayer();
            services.AddInfrastructureLayer(
                Configuration.GetConnectionString("DefaultConnection"));
            services.AddScoped <CredentialsService>();

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddScoped<INotificationRepository, NotificationRepositoryHandler>();
            services.AddScoped<INotificationService, NotificationService>();

            services.AddScoped<IBillService, BillService>();
            services.AddScoped<IPdfCreation, PdfCreation>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDQ4ODMyQDMxMzkyZTMxMmUzMGo0R1FZZUUxWjE5WEFUd01hWXVlbllPTFllcG50R0UvTEhNbS9ocGVJWlU9"); // TODO: move to another file
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
