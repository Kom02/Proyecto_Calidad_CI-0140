using System.Net.Mime;
using EmprendeUCR.Domain.PaymentMethods.Repositories;
using EmprendeUCR.Domain.PaymentInfos.Repositories;
using EmprendeUCR.Infrastructure.PaymentMethods;
using EmprendeUCR.Infrastructure.PaymentMethods.Repositories;
using EmprendeUCR.Infrastructure.PaymentInfos.PaymentInformation;
using EmprendeUCR.Infrastructure.PaymentInfos.PaymentInformation.Repositories;
using EmprendeUCR.Infrastructure.PaymentInfos.SinpeMovil;
using EmprendeUCR.Infrastructure.PaymentInfos.SinpeMovil.Repositories;
using EmprendeUCR.Infrastructure.PaymentInfos.SinpeIban;
using EmprendeUCR.Infrastructure.PaymentInfos.SinpeIban.Repositories;
using EmprendeUCR.Infrastructure.PaymentInfos.Card;
using EmprendeUCR.Infrastructure.PaymentInfos.Card.Repositories;
using EmprendeUCR.Infrastructure.PaymentInfos.HasPaymentInfos;
using EmprendeUCR.Infrastructure.PaymentInfos.HasPaymentInfos.Repositories;
//using EmprendeUCR.Infrastructure.Reports.Repositories;
//For chats
using EmprendeUCR.Domain.Chats.Repositories;
using EmprendeUCR.Infrastructure.Chats.TheChat;
using EmprendeUCR.Infrastructure.Chats.TheChat.Repositories;
using EmprendeUCR.Infrastructure.Chats.TheMessage;
using EmprendeUCR.Infrastructure.Chats.TheMessage.Repositories;
using EmprendeUCR.Infrastructure.Chats.TheUtilizesChat;
using EmprendeUCR.Infrastructure.Chats.TheUtilizesChat.Repositories;

using Microsoft.Extensions.DependencyInjection;
using EmprendeUCR.Domain.EntrepreneurContext.Repositories;
using Microsoft.EntityFrameworkCore;
using EmprendeUCR.Infrastructure.Entrepreneurs;
using EmprendeUCR.Infrastructure.Entrepreneurs.Repositories;
using EmprendeUCR.Infrastructure.Categories;
using EmprendeUCR.Domain.Categories.Repositories;
using EmprendeUCR.Infrastructure.Categories.Repositories;

namespace EmprendeUCR.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(
        this IServiceCollection services,
        string connectionString)
        {
            services.AddDbContext<PaymentMethodsDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ISinpeMovilPaymentMethodRepository, SinpeMovilPaymentMethodRepository>();
            services.AddScoped<ISinpeIbanPaymentMethodRepository, SinpeIbanPaymentMethodRepository>();
            services.AddScoped<ICardPaymentMethodRepository, CardPaymentMethodRepository>();
            services.AddDbContext<PaymentInfoDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IPaymentInfoRepository, PaymentInfoRepository>();
            services.AddDbContext<SinpeMovilPaymentInfoDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ISinpeMovilPaymentInfoRepository, SinpeMovilPaymentInfoRepository>();
            services.AddDbContext<SinpeIbanPaymentInfoDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ISinpeIbanPaymentInfoRepository, SinpeIbanPaymentInfoRepository>();
            services.AddDbContext<CardPaymentInfoDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ICardPaymentInfoRepository, CardPaymentInfoRepository>();
            services.AddDbContext<HasPaymentInfoDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IHasPaymentInfoRepository, HasPaymentInfoRepository>();

            //For chats
            services.AddDbContext<ChatDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddDbContext<MessageDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddDbContext<UtilizesChatDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUtilizesChatRepository, UtilizesChatRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddDbContext<CategoriesDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ICategoryRepository, CategoriesRepository>();
            services.AddDbContext<EntrepreneursDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IProductServiceRepository, ProductServiceRepository>();

            return services;
        }
    }
}