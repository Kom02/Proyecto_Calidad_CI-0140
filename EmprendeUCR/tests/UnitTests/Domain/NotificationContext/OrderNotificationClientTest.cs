using EmprendeUCR_WebApplication.Domain.NotificationContext;
using FluentAssertions;
using Xunit;
namespace EmprendeUCR.UnitTests.Domain.NotificationContext
{
    public class OrderNotificationClientTest
    {
        [Fact]
        public void NotificationMessageAsDerivativeClient()
        {
            // arrange
            OrderNotificationEntrepeneur notification = new OrderNotificationEntrepeneur();
            notification.nameClient = "Juan";
            // act
            Notification notification1 = (Notification)notification;
            var message = notification1.ToString();
            // assert
            message.Should().Be("Tiene un nuevo pedido de Juan");
        }

    }
}
