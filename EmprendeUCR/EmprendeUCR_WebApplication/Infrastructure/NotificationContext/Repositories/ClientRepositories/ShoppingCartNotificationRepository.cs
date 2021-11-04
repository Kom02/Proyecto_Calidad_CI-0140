using EmprendeUCR_WebApplication.Data.Entities;
using EmprendeUCR_WebApplication.Domain.Core.Repositories;
using EmprendeUCR_WebApplication.Domain.NotificationContext;
using EmprendeUCR_WebApplication.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.Abstracts;
using TableDependency.SqlClient.Base.EventArgs;
using TableDependency.SqlClient.Where;

namespace EmprendeUCR_WebApplication.Infrastructure.NotificationContext.Repositories.ClientRepositories
{
    public class ShoppingCartNotificationRepository : INotificationRepository
    {
        private readonly NotificationDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        private IConfiguration _configuration;
        public INotificationRepository Next { set; get; }
        private string EmailToListen { set; get; }
        public event newEventNotification onEventNotification;
        SqlTableDependency<Shopping_Cart_Has> sqlTableDependency;
        public ShoppingCartNotificationRepository(NotificationDbContext unitOfWork, IConfiguration configuration)
        {
            _dbContext = unitOfWork;
            _configuration = configuration;
        }

        public void EventsSubscriptions(UserNotification UserNotification)
        {
            // Subscription is created
            // Email that wants to be listen
            this.EmailToListen = UserNotification.Email;

            var mapper = new ModelToTableMapper<Shopping_Cart_Has>();

            mapper.AddMapping(e => e.Email, "Email");
            // Where clause
            Expression<Func<Shopping_Cart_Has, bool>> expression = e =>
                   e.Email == (string)EmailToListen; 

            ITableDependencyFilter whereCondition = new SqlTableDependencyFilter<Shopping_Cart_Has>(
            expression,
            mapper);
            // Create dependency in Order table with previous where clause
            sqlTableDependency = new SqlTableDependency<Shopping_Cart_Has>(_configuration.GetConnectionString("DefaultConnection"), "Shopping_Cart_Has", filter: whereCondition, mapper: mapper);
            sqlTableDependency.OnChanged += this.ShoppingCartChange;

            if (Next is not null)
            {
                Next.EventsSubscriptions(UserNotification);
            }
            // User subscribed
            this.onEventNotification += UserNotification.QuantityEvent;
            // Begin to listen changes
            sqlTableDependency.Start();
        }

        

        public int GetProductsQuantity(UserNotification UserNotification)
        {
            return _dbContext.Shopping_Cart_Has.Where(sc => sc.Email == EmailToListen).Count();
        }

        public void Unsubscription(UserNotification UserNotification)
        {
            this.onEventNotification -= UserNotification.QuantityEvent;
            // Begin to listen changes
            if (sqlTableDependency is not null)
            {
                sqlTableDependency.Stop();
            }
        }
        private void ShoppingCartChange(object sender, RecordChangedEventArgs<Shopping_Cart_Has> e)
        {
            onEventNotification.Invoke(this, new NotificationChangeEventArgs(false));
        }
    }
}
