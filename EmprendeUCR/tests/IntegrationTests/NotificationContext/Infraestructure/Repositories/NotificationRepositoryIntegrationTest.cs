using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using EmprendeUCR_WebApplication.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using EmprendeUCR.IntegrationTests.EmprendeUCR;
using EmprendeUCR_WebApplication;
using EmprendeUCR_WebApplication.Domain.NotificationContext;

namespace EmprendeUCR.IntegrationTests.OrderContext.Infraestructure.Repositories
{
    public class NotificationRepositoryIntegrationTest : IClassFixture<EmprendeUCRNotificationContextFactory<Startup>>
    {
        private readonly EmprendeUCRNotificationContextFactory<Startup> _factory;

        public NotificationRepositoryIntegrationTest(EmprendeUCRNotificationContextFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public void GetNotificationQuantityEntrepeneur()
        {   
            string entrepreneurEmail = "saguilar1999@hotmail.com";
            var user = new UserNotification(entrepreneurEmail, 2);
            // arrange
            var repository = _factory.Server.Services.GetRequiredService<INotificationRepository>();
            // act
            repository.GetNotificationsQuantity(user);

            // assert
            user.notificationQuantity.Should().Be(3);
        }

        [Fact]
        public void GetNotificationQuantityClient()
        {
            string clientEmail = "juan.valverde@ucr.ac.cr";
            var user = new UserNotification(clientEmail, 1);
            // arrange
            var repository = _factory.Server.Services.GetRequiredService<INotificationRepository>();
            // act
            repository.GetNotificationsQuantity(user);

            // assert
            user.notificationQuantity.Should().Be(3);
        }

        [Fact]
        public void GetNotificationyClient()
        {
            string clientEmail = "juan.valverde@ucr.ac.cr";
            var user = new UserNotification(clientEmail, 1);
            // arrange
            var repository = _factory.Server.Services.GetRequiredService<INotificationRepository>();
            // act
            repository.GetNotifications(user);

            // assert
            foreach (var notification in user.Notifications) {
                notification.ToString().Should().Be("Su pedido a Silvia fue Aceptado");
            }
        }

        /*[Fact]
        public void GetNotificationInUserNotification()
        {
            string entrepreneurEmail = "saguilar1999@hotmail.com";
            var user = new UserNotification(entrepreneurEmail, 2);
            // arrange
            var repository = _factory.Server.Services.GetRequiredService<INotificationRepository>();
            // act
            repository.GetNotifications(user);

            // assert
            user.notificationQuantity.Should().Be(2);
        }

        */


        [Fact]
        public void GetNotificationyEntrepreneur()
        {
            // arrange
            string entrepreneurEmail = "saguilar1999@hotmail.com";
            var user = new UserNotification(entrepreneurEmail, 2);
            var repository = _factory.Server.Services.GetRequiredService<INotificationRepository>();

            // act
            repository.GetNotifications(user);

            // assert
            user.Notifications[0].ToString().Should().Be("Tiene un nuevo pedido de Juan");
            user.Notifications[1].ToString().Should().Be("Tiene un nuevo pedido de Juan");
        }
    }
}
