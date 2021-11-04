using EmprendeUCR_WebApplication.Domain.NotificationContext;
using FluentAssertions;
using Xunit;
namespace EmprendeUCR.UnitTests.Domain.NotificationContext
{
    public class OrderNotificationEntrepeneurTest
    {
        [Fact]
        public void NotificationMessageAsDerivativeEntrepeneur()
        {
            // arrange
            OrderNotificationClient notification = new OrderNotificationClient();
            notification.NameEntrepenur = "Juan";
            notification.State = "Aceptado";
            // act
            Notification notification1 = (Notification)notification;
            var message = notification1.ToString();
            // assert
            message.Should().Be("Su pedido a Juan fue Aceptado");
        }

    }
}